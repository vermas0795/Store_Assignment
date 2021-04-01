using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repository.Entities
{
    public partial class AppRole
    {
        public AppRole()
        {
            AppUser = new HashSet<AppUser>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? Discount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AppUser> AppUser { get; set; }
    }
}
