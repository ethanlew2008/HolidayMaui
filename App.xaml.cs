namespace HolidayMaui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        Routing.RegisterRoute("HolidayTemplate", typeof(HolidayMaui.View.HolidayTemplate)); // Registering HolidayTemplate route

    }
}
