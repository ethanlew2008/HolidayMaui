using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayMaui
{
    public class CountryCodes
    {
        public string result { get; set; }
        public string documentation { get; set; }
        public string terms_of_use { get; set; }
        public List<List<string>> supported_codes { get; set; } = new List<List<string>>();
    }
}

