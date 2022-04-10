using System;
using Dwapi.Prep.SharedKernel.Interfaces;
using Dwapi.Prep.SharedKernel.Tests.TestData.TestData.Models;

namespace Dwapi.Prep.SharedKernel.Tests.TestData.TestData.Interfaces
{
    public interface ITestCarRepository : IRepository<TestCar,Guid>
    {

    }
}
