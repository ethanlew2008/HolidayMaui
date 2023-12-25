using HolidayMaui.Resources.Languages;
using Nager.Country;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
//using static Android.Icu.Text.IDNA;

namespace HolidayMaui.ViewModels
{
    public class TemplateViewModel : BindableBase
    {
        DateTime start;
        DateTime end;

        private readonly object lockObject = new object();

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

        public string LocTime
        {
            get { return loctime; }
            set
            {
                if (loctime != value)
                {
                    loctime = value;
                    OnPropertyChange("LocTime");
                }
            }
        }
        private string loctime;

        public TemplateViewModel(DateTime sdate, DateTime edate, string Country)
        {        
            start = sdate;
            end = edate;
            CountryName = Country;
            Build();
            
        }

        public async void Build()
        {
            string build = "";
            if (DateTime.Today < start) 
            {
                int until = (start - DateTime.Today).Days;
                build = until + " " + AppResources.DaysToGo + "!";
            }
            else if (DateTime.Today > end) 
            { 
                int since = (DateTime.Today - end).Days;
                build = since + " " + AppResources.DaysAgo;
            }
            else if (DateTime.Today >= start && DateTime.Today <= end) 
            {
                int left = (end - DateTime.Today).Days;
                build = left + " " + AppResources.DaysLeft;
            }
            Days = build;

            From = start.ToString("d MMM, yy"); 
            To = end.ToString("d MMM, yy");

            var CountryProv = new CountryProvider();
            var CountryInf = CountryProv.GetCountryByName(CountryName);
            string IsoCode = CountryInf.Alpha2Code.ToString();

            RegionInfo RegionInf = new RegionInfo(IsoCode);
            Currency = RegionInf.ISOCurrencySymbol.ToString();

            Thread thread = new Thread(new ThreadStart(TimeThread));
            thread.Start();

        }



        private void TimeThread()
        {
            while (true)
            {
                lock (lockObject)
                {
                    //Delay Between Days
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        LocTime = DateTime.Now.ToString("HH:mm");
                        
                    });
                    Thread.Sleep(60000);
                }
            }


        }



    }
}
