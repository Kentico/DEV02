using System;

using CMS.EmailEngine;
using CMS.DataEngine;

using DoctorAppointments;

public class AppointmentEvents
{
    /// <summary>
    /// Executed whenever a new record of AppointmentInfo class is inserted
    /// </summary>
    public static void Insert_After(object sender, ObjectEventArgs e)
    {
        // Cast object to AppoinmentInfo class so that we can access its properties
        var appointment = (AppointmentInfo)e.Object;

        // Get DoctorInfo in order to retrieve his e-mail
        var doctor = DoctorInfoProvider.GetDoctorInfo(appointment.AppointmentDoctorID);

        if (doctor != null)
        {
            // Prepare body of e-mail
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

            // Create e-mail
            var email = new EmailMessage()
            {
                Subject = string.Format("New appointment: {0} {1}", appointment.AppointmentPatientFirstName, appointment.AppointmentPatientLastName),
                Recipients = doctor.DoctorEmail,
                PlainTextBody = plainTextBody,
                Body = htmlBody,
                From = "noreply@local.com"
            };

            // Send e-mail
            EmailSender.SendEmail(email);
        }
    }
}