using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repository.Entities
{
    public partial class AppUser
    {
        public AppUser()
        {
            EstimationLogs = new HashSet<EstimationLogs>();
        }

        public long Id { get; set; }
        public string LoginName { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual AppRole Role { get; set; }
        public virtual ICollection<EstimationLogs> EstimationLogs { get; set; }
    }
}
