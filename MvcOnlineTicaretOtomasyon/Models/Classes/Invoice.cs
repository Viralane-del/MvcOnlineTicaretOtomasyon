using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicaretOtomasyon.Models.Classes
{
	public class Invoice
	{
		[Key]
        public int InvoiceId { get; set; }

		[Column(TypeName = "Char")]
		[StringLength(1)]
        [Display(Name = "Seri No")]
        public string InvoiceSerialNumber { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(6)]
        [Display(Name = "Sıra No")]
        public string InvoicesEquence { get; set; }
        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        [Display(Name = "Saat")]
        public string Hour { get; set; }

        [Display(Name = "Vergi Dairesi")]
        [Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string TaxOffice { get; set; }

        [Display(Name = "Teslim Eden")]
        [Column(TypeName = "Varchar")]
		[StringLength(30)]
		public string Receiver { get; set; }

        [Display(Name = "Teslim Alan")]
        [Column(TypeName = "Varchar")]
		[StringLength(30)]
		public string Delivered  { get; set; }

        public decimal Total { get; set; }
        public ICollection<InvoicePen> InvoicePens { get; set; }
	}
}