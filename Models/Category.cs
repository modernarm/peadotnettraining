using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PEADotNetTraining.Models
{
    [Table("category")]
    public class Category
    {
        //[Key]
        [Display(Name="รหัส")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Display(Name ="ประเภทสินค้า")]
        [Required(ErrorMessage ="กรุณาป้อนข้อมูลประเภทสินค้าด้วย")]
        public string CategoryName { get; set; }
        [Display(Name ="สถานะ")]
        public bool IsActive { get; set; }
    }
}
