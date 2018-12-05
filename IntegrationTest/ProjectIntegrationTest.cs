using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest
{
    [TestFixture]
    public class ProjectIntegrationTest
    {

        [Test]
        public void ProjectTest_ConstructorShouldSetPackageRepository_CorrectObject()
        {
            Mock<IRepository<IPackage>> StubPackageRepository = new Mock<IRepository<IPackage>>();
            Project project = new Project("name", "location", StubPackageRepository.Object);
            Assert.AreEqual(StubPackageRepository.Object, project.PackageRepository);
        }
    }
}
