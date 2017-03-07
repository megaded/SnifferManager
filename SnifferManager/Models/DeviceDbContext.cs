namespace SnifferManager
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class DeviceDbContext : DbContext
    {
        public DeviceDbContext()
            : base("name=devicedbEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
       
        }

        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Check> Checks { get; set; }
        public virtual DbSet<Logmessagetypes> Logmessagetypes { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Params> Params { get; set; }
        public virtual DbSet<Querylog> Querylog { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
    }
}
