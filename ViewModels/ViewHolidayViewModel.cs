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

        private readonly INavigation _navigation;

        public ViewHolidayViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Width = DeviceDisplay.MainDisplayInfo.Width;
            PopulateList();
        }

        public async void PopulateList()
        {
            string filepath = Path.Combine(FileSystem.AppDataDirectory, "Countries.txt");
            if (!File.Exists(filepath)) { return; }
            StreamReader reader = new StreamReader(filepath);
            while (!reader.EndOfStream) { Countries.Add(reader.ReadLine()); }
            reader.Close();
        }
     

        public async void ListClicked(string Country)
        {
            StreamReader readercountry = new StreamReader(Path.Combine(FileSystem.AppDataDirectory, "Countries.txt"));
            StreamReader readerstartdate = new StreamReader(Path.Combine(FileSystem.AppDataDirectory, "StartDates.txt"));
            StreamReader readerenddate = new StreamReader(Path.Combine(FileSystem.AppDataDirectory, "EndDates.txt"));

            int counter = 0;
            string line = "";

            while (line != Country)
            {
                line = readercountry.ReadLine();
                counter++;
            }

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            for (int i = 0; i < counter; i++) { start = Convert.ToDateTime(readerstartdate.ReadLine()); }
            for (int i = 0; i < counter; i++) { end = Convert.ToDateTime(readerenddate.ReadLine()); }

            readercountry.Close();
            readerstartdate.Close();
            readerenddate.Close();

            await _navigation.PushModalAsync(new HolidayTemplate(start,end,Country));
        }

       
    }
}
