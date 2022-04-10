using System;
using Dwapi.Prep.SharedKernel.Infrastructure.Data;
using Dwapi.Prep.SharedKernel.Tests.TestData.TestData.Interfaces;
using Dwapi.Prep.SharedKernel.Tests.TestData.TestData.Models;
using Microsoft.EntityFrameworkCore;

namespace Dwapi.Prep.SharedKernel.Infrastructure.Tests.TestData
{

    public class TestCarRepository :BaseRepository<TestCar,Guid>,  ITestCarRepository
    {
        public TestCarRepository(DbContext context) : base(context)
        {
        }
    }
}
