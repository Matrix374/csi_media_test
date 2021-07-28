using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using csi_media_test.Models;

namespace csi_media_test.Data
{
    public class csiDBContext : DbContext
    {
        public csiDBContext (DbContextOptions<csiDBContext> options)
            : base(options)
        {
        }

        public DbSet<DBO_SortedNumModel> SortedNumModel { get; set; }
    }
}