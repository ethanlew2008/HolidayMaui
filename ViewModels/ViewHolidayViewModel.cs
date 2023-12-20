using HolidayMaui.View;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows.Input;

namespace HolidayMaui
{
    public class ViewHolidayViewModel : BindableBase
    {

        public double Width
        {
            get { return width; }
            set
            {
                if (width != value)
                {
                    width = value;
                    OnPropertyChange("Width");
                }
            }
        }
        private double width;


        string Selected = "";

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

        public ICommand listselect { get; set; }

        private readonly INavigation _navigation;


        public ViewHolidayViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Width = DeviceDisplay.MainDisplayInfo.Width;
            listselect = new Command(ListClicked);
            PopulateList();
        }

        public async void PopulateList()
        {
            string filepath = Path.Combine(FileSystem.AppDataDirectory, "Countries.txt");
            StreamReader reader = new StreamReader(filepath);

            while (!reader.EndOfStream)
            {
                Countries.Add(reader.ReadLine());
            }
        }

        public async void ListClicked()
        {
            StreamReader readercountry = new StreamReader(Path.Combine(FileSystem.AppDataDirectory, "Countries.txt"));
            //StreamReader readerstartdate = new StreamReader(Path.Combine(FileSystem.AppDataDirectory, "StartDates.txt"));
            //StreamReader readerenddate = new StreamReader(Path.Combine(FileSystem.AppDataDirectory, "EndDates.txt"));

            int counter1 = 0;
            string iscountry = "";


            //while(iscountry != )
            //{
            //    iscountry = readercountry.ReadLine();
            //    counter1++;
            //}

 

            //await _navigation.PushModalAsync(new HolidayTemplate(Convert.ToDateTime(line),Convert.ToDateTime(line2)));
        }

       
    }
}
