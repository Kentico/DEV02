using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoctorAppointments;
using CMS.Helpers;

public partial class CMSWebParts_DoctorAppointments_WebUserControl : CMS.PortalControls.CMSAbstractWebPart
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Doctor.DataSource = DoctorInfoProvider.GetDoctors().TypedResult;
        Doctor.DataValueField = "DoctorID";
        Doctor.DataTextField = "DoctorFirstName";
        Doctor.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        AppointmentInfo Daco = new AppointmentInfo();
        Daco.AppointmentPatientFirstName = FirstName.Text;
        Daco.AppointmentPatientLastName = LastName.Text;
        Daco.AppointmentPatientEmail = Email.Text;
        Daco.AppointmentPatientPhoneNumber = PhoneNumber.Text;
        Daco.AppointmentPatientBirthDate = ValidationHelper.GetDateTime( DateOfBirth.Text, DateTime.Now);
        Daco.AppointmentDate = ValidationHelper.GetDateTime(DateOfTheAppointment.Text, DateTime.Now);
        Daco.AppointmentDoctorID = ValidationHelper.GetInteger(Doctor.SelectedValue, 0);
        AppointmentInfoProvider.SetAppointmentInfo(Daco);
    }
}