namespace HolidayMaui;

public partial class NewHolidayPage : ContentPage
{
	public NewHolidayPage()
	{
        InitializeComponent();
        BindingContext = new NewHolidayViewModel();
        //CurrencyDropDown.SelectedItem = "Currency";
        //CountryDropdown.ScaleTo(CountryDropdown.SelectedIndex);
    }
}