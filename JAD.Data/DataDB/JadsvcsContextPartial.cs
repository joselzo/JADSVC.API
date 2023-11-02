using JADSVC.Data.DataDB.StoreProcedure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADSVC.Data.DataDB
{
    public partial class JadsvcsContext
    {
        public virtual DbSet<SPGetUser> SPGetUsers { get; set; }
        public virtual DbSet<spgetLevelsandFeatures> spgetLevelsandFeatures { get; set; }
        public virtual DbSet<SPGetFeatureByIdUser> SPGetFeatureByIdUser { get; set; }
        public virtual DbSet<spGetServiceOrderByIdUser> spGetServiceOrderByIdUser { get; set; }

        public async Task<List<SPGetUser>> ExecuteSPGetUserAsync(int id)
        {
            return await SPGetUsers.FromSqlRaw("spGetUser {0}", id).ToListAsync();
        }

        public async Task<List<spgetLevelsandFeatures>> spgetLevelsandFeaturesAsync()
        {
            return await spgetLevelsandFeatures.FromSqlRaw("spgetLevelsandFeatures").ToListAsync();
        }
        public async Task<List<SPGetFeatureByIdUser>> SPGetFeatureByIdUserAsync(int id)
        {
            return await SPGetFeatureByIdUser.FromSqlRaw("SPGetFeatureByIdUser {0}", id).ToListAsync();
        }

        public async Task<List<spGetServiceOrderByIdUser>> spGetServiceOrderByIdUserAsync(int id)
        {
            return await spGetServiceOrderByIdUser.FromSqlRaw("spGetServiceOrderByIdUser {0}", id).ToListAsync();
        }

    }
}
