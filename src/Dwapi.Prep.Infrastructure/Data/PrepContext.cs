using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.SharedKernel.Infrastructure.Data;
using Dwapi.Prep.SharedKernel.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Serilog;
using Z.Dapper.Plus;

namespace Dwapi.Prep.Infrastructure.Data
{
    public class PrepContext : BaseContext
    {
        public DbSet<Docket> Dockets { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<MasterFacility> MasterFacilities { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Manifest> Manifests { get; set; }
        public DbSet<Cargo> Cargoes { get; set; }
        public DbSet<PatientPrep> PrepPatients { get; set; }
        public DbSet<PrepAdverseEvent> PrepAdverseEvents { get; set; }
        public DbSet<PrepBehaviourRisk> PrepBehaviourRisks { get; set; }
        public DbSet<PrepCareTermination> PrepCareTerminations { get; set; }
        public DbSet<PrepLab> PrepLabs { get; set; }
        public DbSet<PrepPharmacy> PrepPharmacys { get; set; }
        public DbSet<PrepVisit> PrepVisits { get; set; }
        public DbSet<PrepMonthlyRefill> PrepMonthlyRefills{ get; set; }



        public PrepContext(DbContextOptions<PrepContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DapperPlusManager.Entity<Docket>().Key(x => x.Id).Table($"{nameof(PrepContext.Dockets)}");
            DapperPlusManager.Entity<Subscriber>().Key(x => x.Id).Table($"{nameof(PrepContext.Subscribers)}");
            DapperPlusManager.Entity<MasterFacility>().Key(x => x.Id).Table($"{nameof(PrepContext.MasterFacilities)}");
            DapperPlusManager.Entity<Facility>().Key(x => x.Id).Table($"{nameof(PrepContext.Facilities)}");
            DapperPlusManager.Entity<Manifest>().Key(x => x.Id).Table($"{nameof(PrepContext.Manifests)}");
            DapperPlusManager.Entity<Cargo>().Key(x => x.Id).Table($"{nameof(PrepContext.Cargoes)}");
            DapperPlusManager.Entity<PatientPrep>().Key(x => x.Id).Table($"{nameof(PrepContext.PrepPatients)}");
            DapperPlusManager.Entity<PrepAdverseEvent>().Key(x => x.Id).Table($"{nameof(PrepContext.PrepAdverseEvents)}");
            DapperPlusManager.Entity<PrepBehaviourRisk>().Key(x => x.Id).Table($"{nameof(PrepContext.PrepBehaviourRisks)}");
            DapperPlusManager.Entity<PrepCareTermination>().Key(x => x.Id).Table($"{nameof(PrepContext.PrepCareTerminations)}");
            DapperPlusManager.Entity<PrepLab>().Key(x => x.Id).Table($"{nameof(PrepContext.PrepLabs)}");
            DapperPlusManager.Entity<PrepPharmacy>().Key(x => x.Id).Table($"{nameof(PrepContext.PrepPharmacys)}");
            DapperPlusManager.Entity<PrepVisit>().Key(x => x.Id).Table($"{nameof(PrepContext.PrepVisits)}");
            DapperPlusManager.Entity<PrepMonthlyRefill>().Key(x => x.Id).Table($"{nameof(PrepContext.PrepMonthlyRefills)}");

        }

        public override void EnsureSeeded()
        {
            Log.Debug("seeding...");
            /*
            if (!MasterFacilities.Any())
            {
                var data = SeedDataReader.ReadCsv<MasterFacility>(typeof(PrepContext).Assembly,"Seed","|");
                MasterFacilities.AddRange(data);
            }
            */

            if (!Dockets.Any())
            {
                var data = SeedDataReader.ReadCsv<Docket>(typeof(PrepContext).Assembly,"Seed","|");
                Dockets.AddRange(data);
            }

            if (!Subscribers.Any())
            {
                var data = SeedDataReader.ReadCsv<Subscriber>(typeof(PrepContext).Assembly,"Seed","|");
                Subscribers.AddRange(data);
            }
            SaveChanges();
            Log.Debug("seeding DONE");
        }
    }
}
