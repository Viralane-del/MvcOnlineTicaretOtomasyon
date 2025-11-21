using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicaretOtomasyon.Models.Classes
{
	public class InvoicePen
	{
        [Key]
		public int InvoicePenId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(100)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Miktar")]
        public int Quantity { get; set; }
        [Display(Name = "Birim Fiyat")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Tutar")]
        public decimal Amount { get; set; }
        [Display(Name = "Fatura ID")]
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
	}
}