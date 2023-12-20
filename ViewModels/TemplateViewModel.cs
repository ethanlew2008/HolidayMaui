using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayMaui.ViewModels
{
    public class TemplateViewModel : BindableBase
    {
        DateTime start;
        DateTime end;

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
        public TemplateViewModel(DateTime sdate, DateTime edate)
        {        
            start = sdate;
            end = edate;
            Build();
        }

        public void Build()
        {
            string build = "";
            if (DateTime.Now < start) 
            {
                int until = (start - DateTime.Now).Days; 
                build = until + " Days To Go!"; 
            }
            else if (DateTime.Now > end) 
            { 
                int since = (DateTime.Now - end).Days; 
                build = since + " Days Ago"; 
            }
            else if (DateTime.Now >= start && DateTime.Now <= end) 
            {
                int left = (end - DateTime.Now).Days; 
                build = left + " Days Left!"; 
            }

            Days = build;
        }
    }
}
