namespace HolidayMaui;

public partial class ViewHolidayPage : ContentPage
{
	public ViewHolidayPage(INavigation navigation)
	{
		InitializeComponent();
        BindingContext = new ViewHolidayViewModel(navigation);
    }

    private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var navigation = App.Current.MainPage.Navigation;
        ViewHolidayViewModel viewHolidayViewModel = new ViewHolidayViewModel(navigation);
        viewHolidayViewModel.ListClicked();
    }
}