namespace HolidayMaui;

public partial class NewHolidayPage : ContentPage
{

    private readonly NewHolidayViewModel _viewModel;

    public NewHolidayPage(INavigation navigation)
	{
            


        InitializeComponent();
        _viewModel = new NewHolidayViewModel(navigation);
        BindingContext = _viewModel; 
        //CurrencyDropDown.SelectedItem = "Currency";
        //CountryDropdown.ScaleTo(CountryDropdown.SelectedIndex);
    }
}