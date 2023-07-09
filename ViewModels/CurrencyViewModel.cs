using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
namespace HolidayMaui
{
    public class CurrencyViewModel : BindableBase
    {
        APIClient currencyclient = new APIClient();
           
        public string Currency1 { get { return currency1; }
            set
            {
                if(currency1 != value)
                {
                    currency1 = value;
                    OnPropertyChange("Currency1");
                }
            }
        }
        private string currency1 = "";

        public string Currency2
        {
            get { return currency2; }
            set
            {
                if (currency2 != value)
                {
                    currency2 = value;
                    OnPropertyChange("Currency2");
                }
            }
        }
        private string currency2 = "";

        public List<string> Currencies
        {
            get { return currencies; }
            set
            {             
                if(currencies != value)
                {
                    currencies = value;
                    OnPropertyChange("Currencies");
                }
            }
        } 
        public List<string> currencies = new List<string>();

        public ICommand CurrencyButton { get; set; }

        public string Input
        {
            get { return input; }
            set
            {
                if (input != value)
                {
                    input = value;
                    OnPropertyChange("Input");
                }
            }
        }
        private string input;

        public CurrencyViewModel()
        {
            init();
            CurrencyButton = new Command(CurrencyButtonClicked);
        }

        async public void init()
        {
            CountryCodes countryCodes = await currencyclient.GetCountryCodes();
            string cc = "";
            List<string> temp = new List<string>();
            for (int i = 0; i < countryCodes.supported_codes.Count; i++)
            {
                string code = countryCodes.supported_codes[i][0];
                string name = countryCodes.supported_codes[i][1];
                temp.Add(code + " - " + name);
                
            }
            Currencies = temp;
        }

        public async void CurrencyButtonClicked()
        {
            string code1 = "";
            string code2 = "";
            if (Currency1 == "" || Currency2 == "") { return; }
            if(code1 == null) { return; }


            code1 = Currency1.Split('-')[0];
            code2 = Currency2.Split('-')[0];

            code1 = code1.Trim();
            code2 = code2.Trim();

            double result = await currencyclient.ConvertPair(code1, code2, Convert.ToDouble(Input));
            result = Math.Round(result, 2);
            Input = "" + result;

        }


    }
}
