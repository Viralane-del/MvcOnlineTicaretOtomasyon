using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicaretOtomasyon.Models.Classes
{
	public class Current
	{
        [Key]
        public int CurrentId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(30, ErrorMessage ="En Fazla 30 Karakter Yazabilirsiniz!")]
        [Display(Name = "Ad")]
        public string CurrentName { get; set; }
       

        [Column(TypeName = "Varchar")]
		[StringLength(30)]
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez!")]
        [Display(Name = "Soyad")]
        public string CurrentSurName { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(13)]
        [Display(Name = "Şehir")]
        public string CurrentCity { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
        [Display(Name = "E-Mail")]
        public string CurrentEmail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Password { get; set; }

        public bool Status { get; set; }
        public ICollection<SalesMovement> SalesMovements { get; set; }
	}
}