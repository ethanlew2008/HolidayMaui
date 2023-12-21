using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMaui.ViewModels
{
    public class TemplateViewModel : BindableBase
    {
        DateTime start;
        DateTime end;

        public string Days
        {
            get { return days; }
            set
            {
                if (days != value)
                {
                    days = value;
                    OnPropertyChange("Days");
                }
            }
        }
        private string days;

        public string From
        {
            get { return from; }
            set
            {
                if (from != value)
                {
                    from = value;
                    OnPropertyChange("From");
                }
            }
        }
        private string from;

        public string To
        {
            get { return to; }
            set
            {
                if (to != value)
                {
                    to = value;
                    OnPropertyChange("To");
                }
            }
        }
        private string to;

        public string Currency
        {
            get { return currency; }
            set
            {
                if (currency != value)
                {
                    currency = value;
                    OnPropertyChange("Currency");
                }
            }
        }
        private string currency;

        public string CountryName = "";

        public TemplateViewModel(DateTime sdate, DateTime edate, string Country)
        {        
            start = sdate;
            end = edate;
            Build();
            CountryName = Country;
        }

        public async void Build()
        {
            string build = "";
            if (DateTime.Now < start) 
            {
                int until = (start - DateTime.Now).Days; 
                build = until + " Days To Go!"; 
            }
            else if (DateTime.Now > end) 
            { 
                int since = (DateTime.Now - end).Days; 
                build = since + " Days Ago"; 
            }
            else if (DateTime.Now >= start && DateTime.Now <= end) 
            {
                int left = (end - DateTime.Now).Days; 
                build = left + " Days Left!"; 
            }
            Days = build;

            From = start.ToString("d MMM, yy"); 
            To = end.ToString("d MMM, yy");

            var myfile = await FileSystem.OpenAppPackageFileAsync("Currencies.csv");
            StreamReader reader = new StreamReader(myfile);
            List<string> temp = new List<string>();

        }
    }
}
