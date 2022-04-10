using System;
using Dwapi.Prep.Core.Command;
using Dwapi.Prep.Core.Domain;
using Dwapi.Prep.Core.Interfaces.Repository;
using Dwapi.Prep.Infrastructure.Data;
using Dwapi.Prep.Infrastructure.Data.Repository;
using Dwapi.Prep.SharedKernel.Exceptions;
using Dwapi.Prep.SharedKernel.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Dwapi.Prep.Core.Tests.CommandHandler
{
    [TestFixture]
    public class EnrollFacilityHandlerTests
    {
        private ServiceProvider _serviceProvider;
        private IMediator _mediator;
        private PrepContext _context;

        [OneTimeSetUp]
        public void Init()
        {
            _serviceProvider = new ServiceCollection()
                .AddDbContext<PrepContext>(o => o.UseInMemoryDatabase(Guid.NewGuid().ToString()))
                .AddScoped<IMasterFacilityRepository, MasterFacilityRepository>()
                .AddScoped<IFacilityRepository, FacilityRepository>()
                .AddMediatR(typeof(ValidateFacilityHandler))
                .BuildServiceProvider();


            _context = _serviceProvider.GetService<PrepContext>();
            _context.MasterFacilities.Add(new MasterFacility(1, "XFacility", "XCounty"));
            _context.MasterFacilities.Add(new MasterFacility(2, "YFacility", "YCounty"));
            _context.Facilities.Add(new Facility(1, "XFacility District", 1));
            _context.SaveChanges();
        }

        [SetUp]
        public void SetUp()
        {
            _mediator = _serviceProvider.GetService<IMediator>();
        }

        [Test]
        public void should_Throw_Exception_Invalid_SiteCode()
        {
            var ex = Assert.Throws<System.AggregateException>(() => EnrollFacility(new Facility(3,"XFac")));
            Assert.AreEqual(typeof(FacilityNotFoundException), ex.InnerException.GetType());
            Console.WriteLine($"{ex.InnerException.Message}");
        }

        [Test]
        public void should_Return_Enrolled_Facility()
        {
            var facilityId = EnrollFacility(new Facility(1, "XFac"));

            var facility = _context.Facilities.Find(facilityId);
            var mflfacility = _context.MasterFacilities.Find(facility.SiteCode);

            Assert.False(facilityId.IsNullOrEmpty());
            Assert.AreEqual(facilityId, facility.Id);
            Assert.True(facility.MasterFacilityId.HasValue);
            Assert.AreEqual(mflfacility.Id, facility.MasterFacilityId.Value);
            Console.WriteLine(facility);
        }

        [Test]
        public void should_Enroll_New_Facility()
        {
            var facilityId = EnrollFacility(new Facility(2, "Y District Hosptial"));

            var facility = _context.Facilities.Find(facilityId);
            var mflfacility = _context.MasterFacilities.Find(facility.SiteCode);

            Assert.False(facilityId.IsNullOrEmpty());
            Assert.AreEqual(facilityId, facility.Id);
            Assert.True(facility.MasterFacilityId.HasValue);
            Assert.AreEqual(mflfacility.Id, facility.MasterFacilityId.Value);
            Console.WriteLine(facility);
        }

        [Test]
        public void should_Snap_Enroll_New_Facility()
        {
            var facilityId = _mediator.Send(new EnrollFacility(1, "XFac (Ke)", "KenyaEMR")).Result;
            var facilityIdVer2 = _mediator.Send(new EnrollFacility(1, "XFac (IQ)", "IQCare")).Result;

            var facility = _context.Facilities.Find(facilityId);
            var mflfacility = _context.MasterFacilities.Find(facility.SiteCode);

            Assert.False(facilityId.IsNullOrEmpty());
            Assert.AreEqual(facilityId, facility.Id);
            Assert.True(facility.MasterFacilityId.HasValue);
            Assert.AreEqual(mflfacility.Id, facility.MasterFacilityId.Value);
            Console.WriteLine(facility);
        }


        private Guid EnrollFacility(Facility facility)
        {
            return _mediator.Send(new EnrollFacility(facility.SiteCode, facility.Name,"IQCare")).Result;
        }
    }
}
