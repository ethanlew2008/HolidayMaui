using System;
using System.Collections.Generic;
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

        public string Selected 
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    OnPropertyChange("Selected");
                }
            }
        }
        private string selected;

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



        public ViewHolidayViewModel()
        {
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

        }

       
    }
}
