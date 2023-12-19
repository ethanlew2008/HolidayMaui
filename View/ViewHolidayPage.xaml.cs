namespace HolidayMaui;

public partial class ViewHolidayPage : ContentPage
{
	public ViewHolidayPage()
	{
		InitializeComponent();
        BindingContext = new ViewHolidayViewModel();
    }

    private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        ViewHolidayViewModel viewHolidayViewModel = new ViewHolidayViewModel();
        viewHolidayViewModel.ListClicked();
    }
}