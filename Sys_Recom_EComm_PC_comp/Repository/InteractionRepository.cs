using Sys_Recom_EComm_PC_comp.Data;
using Sys_Recom_EComm_PC_comp.Interfaces;
using Sys_Recom_EComm_PC_comp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys_Recom_EComm_PC_comp.Repository
{
    public class InteractionRepository : BaseRepository<Interaction>, IInteractionRepository
    {
        public InteractionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
