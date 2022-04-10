using System;
using System.Collections.Generic;
using Dwapi.Prep.SharedKernel.Model;

namespace Dwapi.Prep.SharedKernel.Tests.TestData.TestData.Models
{
    public class TestCar:Entity<Guid>
    {
        public string Name { get; set; }
        public ICollection<TestModel> Models { get; set; }=new List<TestModel>();
    }
}
