using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMaui.Models
{
    class User
    {
        public string Name { get; set; }
        public List<Holiday> Holidays { get; set; }
    }
}
