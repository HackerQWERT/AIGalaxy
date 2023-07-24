namespace AIGalaxy;

public partial class App : Application
{
    private static HubConnection aIGalaxyConnection;
    public static HubConnection AIGalaxyConnection
    {
        get => aIGalaxyConnection;
        set => aIGalaxyConnection = value;
    }

    public App()
	{
		InitializeComponent();
#if WINDOWS

        MainPage = new WindowsAIGalaxyView();
#elif ANDROID
        MainPage = new AndroidAIGalaxyView();
#endif
        _=InitializeConnectionAsync();
        Task.Run(()=> CheckConnectionAndReconnectToServerAsync());

    }

    private async Task InitializeConnectionAsync()
    {

        string url = $"{SignalR.WebsocketUrl}:{SignalR.Port}/{SignalR.AIGalaxyHub}";
        AIGalaxyConnection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();
        try
        {
            await AIGalaxyConnection.StartAsync();

        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
        private async Task CheckConnectionAndReconnectToServerAsync()
        {
            while(true) 
            {
                await Task.Delay(1000);
                if(AIGalaxyConnection.State is not HubConnectionState.Connected)
                {
                    try
                    {
                        await AIGalaxyConnection.StopAsync();
                        await AIGalaxyConnection.StartAsync();
                    }
                    catch(Exception ex) 
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }

            }                



        }

}
