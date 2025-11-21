using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicaretOtomasyon.Models.Classes
{
	public class Category
	{
        [Key]
        public int CategoryId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(100)]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}