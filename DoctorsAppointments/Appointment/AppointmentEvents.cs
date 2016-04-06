using System;

using CMS.Base;
using CMS.EmailEngine;
using CMS.DataEngine;

using DoctorAppointments;

[AppointmentEvents]
public partial class CMSModuleLoader
{
    /// <summary>
    /// Attribute class that ensures the loading of custom handlers.
    /// </summary>
    private class AppointmentEvents : CMSLoaderAttribute
    {
        /// <summary>
        /// The system executes the Init method of the CMSModuleLoader attributes when the application starts.
        /// </summary>
        public override void Init()
        {
            // Assigns custom handlers to events
            AppointmentInfo.TYPEINFO.Events.Insert.After += Insert_After;
        }

        /// <summary>
        /// Register an event that is executed whenever a new record of AppointmentInfo class is inserted
        /// </summary>
        private void Insert_After(object sender, ObjectEventArgs e)
        {
            // cast object to AppoinmentInfo class so that we can access its properties
            var appointment = (AppointmentInfo)e.Object;

            // get DoctorInfo in order to retrieve his e-mail
            var doctor = DoctorInfoProvider.GetDoctorInfo(appointment.AppointmentDoctorID);

            if (doctor != null)
            {
                // prepare body of e-mail
                var plainTextBody = String.Format("There is a new appointment request by {0} {1} for {2}. Please get back to patient with available dates on e-mail address {3}",
                    appointment.AppointmentPatientFirstName,
                    appointment.AppointmentPatientLastName,
                    appointment.AppointmentDate.ToShortDateString(),
                    appointment.AppointmentPatientEmail);

                var htmlBody = String.Format("<h1>New appointment</h1><p>There is a new appointment request by {0} {1} for {2}. Please get back to patient with available dates on e-mail address {3}</p>",
                    appointment.AppointmentPatientFirstName,
                    appointment.AppointmentPatientLastName,
                    appointment.AppointmentDate.ToShortDateString(),
                    appointment.AppointmentPatientEmail);


                // create e-mail
                var email = new EmailMessage()
                {
                    Subject = string.Format("New appointment: {0} {1}", appointment.AppointmentPatientFirstName, appointment.AppointmentPatientLastName),
                    Recipients = doctor.DoctorEmail,
                    PlainTextBody = plainTextBody,
                    Body = htmlBody,
                    From = "noreply@local.com"
                };

                // send e-mail
                EmailSender.SendEmail(email);
            }
        }
    }
}