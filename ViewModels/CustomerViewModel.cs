using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEADotNetTraining.ViewModels
{
    public class CustomerViewModel
    {
        public string fullName { get; set; }
        public int postCode { get; set; }

        public CustomerViewModel()
        {

            fullName = "";
            postCode = 51000;
        }
    }

}
