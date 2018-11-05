using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GigHubApp.Core.ViewModels
{
    public class FutureDate:ValidationAttribute
    {
      
        public override bool IsValid(object value)
        {
            DateTime datetime;
            var isValid=DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy", CultureInfo.CurrentCulture,
                DateTimeStyles.None, 
                out datetime);

            return (isValid && datetime > DateTime.Now);
           
        }

    }
}