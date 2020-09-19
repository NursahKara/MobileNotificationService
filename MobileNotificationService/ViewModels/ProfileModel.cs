using MobileNotificationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileNotificationService.ViewModels
{
    public class ProfileModel
    {
        public int SystemId { get; set; }
        public string Username { get; set; }
        public List<NotificationSubject> NotificationSubjects { get; set; }
    }
}