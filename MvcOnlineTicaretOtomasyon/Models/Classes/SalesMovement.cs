using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicaretOtomasyon.Models.Classes
{
	public class SalesMovement
	{
        [Key]
        public int SalesId { get; set; }
        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }
        [Display(Name = "Miktar")]
        public int Quantity { get; set; }
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Display(Name = "Toplam Fiyat")]
        public decimal TotalPrice { get; set; }       
        public int ProductId { get; set; }        
        public int CurrentId { get; set; }       
        public int StaffId { get; set; }

        [Display(Name = "Ürün")]
        public virtual Product Product { get; set; }
        [Display(Name = "Cari")]
        public  virtual Current Current { get; set; }
        [Display(Name = "Personel")]
        public virtual Staff Staff { get; set; }
	}
}