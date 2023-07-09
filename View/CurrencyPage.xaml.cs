namespace HolidayMaui;

public partial class CurrencyPage : ContentPage
{
	public CurrencyPage()
	{
		InitializeComponent();
        BindingContext = new CurrencyViewModel();
        OutputButton.HorizontalOptions = LayoutOptions.CenterAndExpand;

        
    }
}