using HolidayMaui.ViewModels;

namespace HolidayMaui.View;

public partial class HolidayTemplate : ContentPage
{
	public HolidayTemplate(DateTime start, DateTime end)
	{
        BindingContext = new TemplateViewModel(start,end);
		InitializeComponent();

        

    }
}