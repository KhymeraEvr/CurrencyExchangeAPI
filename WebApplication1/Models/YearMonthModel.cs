using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class YearMonthModel
    {
        private int _month;

        public int Year { get; set; }        
        public int Month
        {
            get { return _month; }
            set
            {
                if (value > 12)
                {
                    Year++;
                    _month = 1;
                }
                else
                {
                    _month = value;
                }
                
            }
        }

        

        public YearMonthModel()
        {
        }

        public YearMonthModel(string sampleDate)
        {
            string[] args = sampleDate.Split('-');
            Year = Convert.ToInt32(args[0]);
            Month = Convert.ToInt32(args[1]);
        }

        public override bool Equals(object obj)
        {
            var model = obj as YearMonthModel;
            return model != null &&
                   Year == model.Year &&
                   Month == model.Month;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Year, Month);
        }

        public override string ToString()
        {
            return $"{Year}-{Month}-01";
        }
    }
}
