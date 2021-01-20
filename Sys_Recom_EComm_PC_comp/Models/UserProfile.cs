using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Models
{
    public class UserProfile : IdentityUser
    {
        public Guid UserProfileID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid KeywordID { get; set; }
        public Guid Searches { get; set; }
        public string UserPhoto { get; set; }
    }
}
