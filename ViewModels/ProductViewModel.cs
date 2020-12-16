using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using PEADotNetTraining.Models;
namespace PEADotNetTraining.ViewModels
{
    public class ProductViewModel : Product
    {
        public SelectList CategoryList {get;set; }
    }
}
