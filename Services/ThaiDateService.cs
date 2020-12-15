using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PEADotNetTraining.Services
{
    public class ThaiDateService : IThaiDateService
    {
        public string ShowThaiDate()
        {
            return DateTime.Now.ToString("dd MMMM yyyy" , new CultureInfo("th-TH"));
        }
    }
}
