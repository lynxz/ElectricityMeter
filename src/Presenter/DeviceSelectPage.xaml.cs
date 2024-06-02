namespace Presenter;

public partial class DeviceSelectPage : ContentPage
{
    public DeviceSelectPage()
    {
        InitializeComponent();
        NextBtn.IsEnabled = false;
        DeviceID.TextChanged += DeviceID_TextChanged;
        NextBtn.Clicked += NextBtn_Clicked;
    }

    private void DeviceID_TextChanged(object? sender, TextChangedEventArgs e)
    {
        NextBtn.IsEnabled = DeviceID.Text.Length > 0;
    }

    private async void NextBtn_Clicked(object? sender, EventArgs e)
    {
        await SecureStorage.SetAsync("DeviceId", DeviceID.Text);
        await Shell.Current.GoToAsync("Meter");
    }
}