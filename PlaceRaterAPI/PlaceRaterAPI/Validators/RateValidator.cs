using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI.Validators
{
    public static class RateValidator
    {
        public static bool isValid(Rate rate)
        {
            if (rate.Login != null && rate.Name != null && rate.City != null && rate.State != null &&
                rate.Stars > 0 && rate.Stars <= 5 &&
                rate.Price > 0 && rate.Price <= 5)
            {
                return true;
            }

            return false;
        }
    }
}
