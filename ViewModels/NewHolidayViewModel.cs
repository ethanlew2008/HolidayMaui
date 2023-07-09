using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HolidayMaui
{
    public class NewHolidayViewModel : BindableBase
    {
        private double width;
        List<string> destinations = new List<string>();


        public double Width { 
            get { return width; } 
            set 
            {
                if(width!= value)
                {
                    width = value;
                    OnPropertyChange("Width");
                }
            } 
        }

        public List<string> Countries
        {
            get { return countries; }
            set
            {
                if (countries != value)
                {
                    countries = value;
                    OnPropertyChange("Countries");
                }
            }   
        }
        public List<string> countries = new List<string>();

        public string SelectedCountry
        {
            get { return selectedcountry; }
            set 
            {
                if (selectedcountry != value)
                {
                    selectedcountry = value;
                    OnPropertyChange("SelectedCountry");
                }
            }
        }
        private string selectedcountry;

        public DateTime SelectedDate
        {
            get { return selecteddate; }
            set
            {
                if (selecteddate != value)
                {
                    selecteddate = value;
                    OnPropertyChange("SelectedDate");
                }
            }
        }
        private DateTime selecteddate;

        public DateTime MinimumDate
        {
            get { return minimumdate; }
            set
            {
                if (minimumdate != value)
                {
                    minimumdate = value;
                    OnPropertyChange("MinimumDate");
                }
            }
        }
        private DateTime minimumdate;


        public NewHolidayViewModel()
         {
            Width = DeviceDisplay.MainDisplayInfo.Width;
            PopulatePicker();
            SelectedDate = DateTime.Now;
            MinimumDate = DateTime.Now;
         }

        public async Task PopulatePicker()
        {
            var myfile = await FileSystem.OpenAppPackageFileAsync("Currencies.csv");
            StreamReader reader = new StreamReader(myfile);
            List<string> temp = new List<string>();

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                var linearray = line.Split(',');
                temp.Add(linearray[1]);
            }

            temp.Sort();
            Countries = temp;
        }


        
    }
}
