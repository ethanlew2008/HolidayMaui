using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace HolidayMaui
{
    internal class MainPageVeiwModel : BindableBase
    {
        //

        public ICommand NewHolidayComm { private set; get; }
        public ICommand ViewHolidayComm { private set; get; }
        public ICommand CurrencyComm { private set; get; }


        private string input;
        public string Input
        {
            get { return input; }
            set
            {

                if (value != input)
                {
                    input = value;
                    OnPropertyChange("Input");
                }

            }
        }

        private ContentPage veiw;

        public MainPageVeiwModel(ContentPage v)
        {
            NewHolidayComm = new Command(NewHolidayPressed);
            ViewHolidayComm = new Command(ViewHolidayPressed);
            CurrencyComm = new Command(CurrencyPressed);         
            veiw = v;
        }


        public async void NewHolidayPressed()
        {
            var navigation = App.Current.MainPage.Navigation;
            await veiw.Navigation.PushAsync(new NewHolidayPage(navigation));
        }



        public async void ViewHolidayPressed()
        {
            var navigation = App.Current.MainPage.Navigation;
            await veiw.Navigation.PushAsync(new ViewHolidayPage(navigation));
        }

        public async void CurrencyPressed()
        {
            await veiw.Navigation.PushAsync(new CurrencyPage());
        }
    }
}
