
namespace HolidayMaui;

public partial class MainPage : ContentPage
{
    private MainPageVeiwModel VeiwModel;

    public MainPage()
	{
		InitializeComponent();
        VeiwModel = new MainPageVeiwModel(this);
        BindingContext = VeiwModel;
    }
}

