using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace imgcrv.Presentation.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }

    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime UploadedAt { get; set; }

        public virtual ApplicationUser User { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}