using HolidayMaui.ViewModels;

namespace HolidayMaui.View;

public partial class HolidayTemplate : ContentPage
{
	public HolidayTemplate(DateTime start, DateTime end,string Country)
	{
        BindingContext = new TemplateViewModel(start,end,Country);
		InitializeComponent();
    }

    void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
           
    }
}