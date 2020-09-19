using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileNotificationService.Models
{
    public class SubjectsDetail
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int DescriptionNo { get; set; }
        [Required]
        public int TalepNo { get; set; }
        [Required]
        public string TalepEden { get; set; }
        [Required]
        public DateTime TalepTarihi { get; set; }
    }
}