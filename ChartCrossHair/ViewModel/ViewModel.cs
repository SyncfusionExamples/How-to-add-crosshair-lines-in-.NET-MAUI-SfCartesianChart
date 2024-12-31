using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartCrossHair
{
    public class ViewModel
    {
        public List<Model> Data { get; set; }

        public ViewModel()
        {
            Data = new List<Model>()
            {
                new Model{Month = "January", High = 6, Low = -3, Number = 1 },
                new Model{Month = "Febrauary", High = 7, Low = -3, Number = 2 },
                new Model{Month = "March", High = 9, Low = 2, Number = 3},
                new Model{Month = "April", High = 16, Low = 6, Number = 4},
                new Model{Month = "May", High = 20, Low = 12, Number = 5},
                new Model{Month = "June", High = 27, Low = 17, Number = 6},
                new Model{Month = "July", High = 29, Low = 20, Number = 7},
                new Model{Month = "August", High = 28, Low = 20, Number = 8},
                new Model{Month = "September", High = 24, Low = 16, Number = 9},
                new Model{Month = "October", High = 18, Low = 10 , Number = 10},
                new Model{Month = "November", High = 12, Low = 5 , Number = 11},
                new Model{Month = "December", High = 13, Low = 4, Number = 12}
            };
        }
    }
}
