using CMS;
using CMS.DataEngine;
 
[assembly: RegisterModule(typeof(DoctorAppointmentsModule))]
 
public class DoctorAppointmentsModule : Module
{
    // Module class constructor, inherits from the base constructor with the code name of the module as the parameter
    public DoctorAppointmentsModule() : base("DoctorAppointments")
    {
    }

    /// <summary>
    /// Initializes the module. Called when the application starts.
    /// </summary>
    protected override void OnInit()
    {
        base.OnInit();
    }
}
