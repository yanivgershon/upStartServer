using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using upStartServer.Data;

namespace upStartServer.Service
{
    public class UpStartDbContext:DbContext
    {
        public UpStartDbContext() : base("UpStartContext")
        {

        }
        public DbSet<Entity> Entities { get; set; }
    }
}