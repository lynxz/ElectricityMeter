namespace Presenter;

public partial class MeterPage : ContentPage
{
    private IDispatcherTimer _timer;
    private DataFetcher _fetcher;
    private const string FMT = "00000000.###";

    public MeterPage()
    {
        InitializeComponent();
        _fetcher = new DataFetcher();
        BackBtn.Clicked += BackBtn_Clicked;
        SetActiveEnergyConsumed(0);
        SetCurrentConsumption(0);
    }

    private async void Timer_Tick(object? sender, EventArgs e)
    {
        var result = await _fetcher.FetchData();
        SetActiveEnergyConsumed(result.ActiveEnergyConsumed);
        SetCurrentConsumption(result.ActivePowerConsumption);
    }

    private void SetActiveEnergyConsumed(double value) => TotalConsumption.Text = $"{value.ToString(FMT)}kWh";

    private void SetCurrentConsumption(double value)
    {
        CurrentConsumption.Text = $"{value.ToString(FMT)}kW";
        foreach (var pointer in Gauge.Axes[0].Pointers)
            pointer.Value = value;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        _fetcher.DeviceId = await SecureStorage.GetAsync("DeviceId");
        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(10);
        _timer.Tick += Timer_Tick;
        _timer.Start();
        base.OnNavigatedTo(args);
    }

    private async void BackBtn_Clicked(object? sender, EventArgs e)
    {
        if (_timer.IsRunning)
            _timer.Stop();

        await Shell.Current.GoToAsync("///DeviceSelection");
    }
}