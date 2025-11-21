using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicaretOtomasyon.Models.Classes
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        [Display(Name = "Kargo Numarası")]
        public string TrackingCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]

        [Display(Name = "Personel")]
        public string Staff { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]

        [Display(Name = "Alıcı")]
        public string Buyer { get; set; }

        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }
    }
}