namespace Presenter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("DeviceSelection", typeof(DeviceSelectPage));
            Routing.RegisterRoute("Meter", typeof(MeterPage));
        }
    }
}
