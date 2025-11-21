using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicaretOtomasyon.Models.Classes
{
	public class Staff
	{
		[Key]
		public int StaffId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(30)]
        [Display(Name = "Personel Adı")]
        public string StaffName { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(30)]
        [Display(Name = "Soyad")]
        public string StaffSurName { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(250)]
        [Display(Name = "Görsel")]
        public string StaffImage { get; set; }	
		public   ICollection<SalesMovement> SalesMovements  { get; set; }
		public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

	}
}