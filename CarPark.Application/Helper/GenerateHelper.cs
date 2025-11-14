using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.Helper
{
    public static class GenerateHelper
    {
       public static decimal CalculatePrice(DateTime enteredAt, DateTime exitAt)
        {
            var duration = exitAt - enteredAt;
            var hours = Math.Ceiling(duration.TotalHours);
            var price = (decimal)hours * 50m;
            return price;
        }
    }
}
