using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PEADotNetTraining.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name="ชื่อสินค้า")]
        [Required(ErrorMessage = "กรูณาระบุบชื่อสินค้า")]
        public string ProductName { get; set; }

        [Display(Name="ราคาสินค้า")]
        [Required(ErrorMessage = "กรุณาระบุราคาสินค้า")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "เพิ่มรูปภาพ")]
        public string ProductImage { get; set; } = "nopic.png";

        [Display(Name = "วันหมดอายุ")]
        [Column(TypeName = ("datetime"))]
        public DateTime ProductExpire { get; set; } = DateTime.Now.AddMonths(3);

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
