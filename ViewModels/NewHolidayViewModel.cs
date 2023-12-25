using HolidayMaui.Models;
using HolidayMaui.Resources.Languages;
using HolidayMaui.Resources.Languages.Countries;
using HolidayMaui.View;
using Microsoft.Maui.Controls;
using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace HolidayMaui
{
    public class NewHolidayViewModel : BindableBase
    {
        private double width;
        List<string> destinations = new List<string>();
        public ICommand savebutton { get; set; }
        public ICommand savebutton1 { get; set; }

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

        public string Flag
        {
            get { return flag; }
            set
            {
                if (flag != value)
                {
                    flag = value;
                    OnPropertyChange("Flag");
                }
            }
        }
        private string flag;

        public DateTime SelectedStartDate
        {
            get { return selectedstartdate; }
            set
            {
                if (selectedstartdate != value)
                {
                    selectedstartdate = value;
                    OnPropertyChange("SelectedStartDate");
                }
            }
        }
        private DateTime selectedstartdate;

        public DateTime SelectedEndDate
        {
            get { return selectedenddate; }
            set
            {
                if (selectedenddate != value)
                {
                    selectedenddate = value;
                    OnPropertyChange("SelectedEndDate");
                }
            }
        }
        private DateTime selectedenddate;
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

        private readonly INavigation _navigation;

        public NewHolidayViewModel(INavigation navigation)
         {
            _navigation = navigation;
            Width = DeviceDisplay.MainDisplayInfo.Width;
            PopulatePicker();
            SelectedStartDate = DateTime.Now;
            SelectedEndDate = DateTime.Now.AddDays(7);
            MinimumDate = DateTime.Now;
            savebutton = new Command(SaveButtonClicked);
            savebutton1 = new Command(SaveButtonClicked1);
        }


        public async void SaveButtonClicked()
        {
            using (StreamWriter streamWriter = File.AppendText(Path.Combine(FileSystem.AppDataDirectory, "Countries.txt")))
            {
                // Write the new line containing the word
                streamWriter.WriteLine(SelectedCountry);
            }
            using (StreamWriter streamWriter = File.AppendText(Path.Combine(FileSystem.AppDataDirectory, "StartDates.txt")))
            {
                // Write the new line containing the word
                streamWriter.WriteLine(SelectedStartDate.ToString());
            }
            using (StreamWriter streamWriter = File.AppendText(Path.Combine(FileSystem.AppDataDirectory, "EndDates.txt")))
            {
                // Write the new line containing the word
                streamWriter.WriteLine(SelectedEndDate.ToString());
            }

            await _navigation.PopToRootAsync();  // Clear stack
            await _navigation.PushAsync(new HolidayTemplate(SelectedStartDate, SelectedEndDate,SelectedCountry));

        }
        public async void SaveButtonClicked1()
        {         
            StreamReader readercountry = new StreamReader(Path.Combine(FileSystem.AppDataDirectory, "Countries.txt"));
            StreamReader readerstartdate = new StreamReader(Path.Combine(FileSystem.AppDataDirectory, "StartDates.txt"));
            StreamReader readerenddate = new StreamReader(Path.Combine(FileSystem.AppDataDirectory, "EndDates.txt"));
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
                try
                {
                    ResourceManager Manager = CountryResource.ResourceManager;

                    temp.Add(Manager.GetString(linearray[1]));
                    
                }
                catch (Exception) { }                
            }

            temp.Sort();
            temp.RemoveRange(0, 4);
            Countries = temp;
           
        }


        
    }
}
