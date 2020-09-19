using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileNotificationService.Models
{
    public class NotificationSubject
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int DescriptionNo { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SmallDescription { get; set; }
        [Required]
        public int SubjectCount { get; set; }
        [Required]
        public string IconPath { get; set; }
    }
}