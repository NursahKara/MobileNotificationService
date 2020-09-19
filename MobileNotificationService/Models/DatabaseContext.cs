using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MobileNotificationService.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("dbcnn") { }
        public DbSet<User> Users { get; set; }
        public DbSet<NotificationSubject> NotificationSubjects { get; set; }
        public DbSet<SubjectsDetail> SubjectsDetails { get; set; }
    }
}