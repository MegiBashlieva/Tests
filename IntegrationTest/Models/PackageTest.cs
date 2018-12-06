using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Models
{
    [TestFixture]
    class PackageTest
    {
        [Test]
        public void Constructor_ShouldThrowException_WhenNameIsNull()
        {
            Mock<IVersion> stubVersion = new Mock<IVersion>();

            Assert.Throws<ArgumentNullException>( () => new Package(null,stubVersion.Object));
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenVersionIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Package("name", null));
        }

        [Test]
        public void Constructor_ShouldSetICollection_WhenDependenciesAreNull()
        {
            Mock<IVersion> stubVersion = new Mock<IVersion>();
            Package package = new Package("name", stubVersion.Object,null);

            Assert.IsInstanceOf<ICollection<IPackage>>(package.Dependencies);
        }

        [Test]
        public void GeteDependecies_ConstructorShouldSetICollection_WhenDependenciesAreNotNull()
        {
            Mock<ICollection<IPackage>> stubDependecies = new Mock<ICollection<IPackage>>();
            Mock<IVersion> stubVersion = new Mock<IVersion>();
            Package package = new Package("name", stubVersion.Object, stubDependecies.Object);

            Assert.AreSame(stubDependecies.Object, package.Dependencies);
        }

        [Test]
        public void Constructor_ShouldSetDependecies_WhenValueNotNull()
        {
            Mock<IVersion> stubVersion = new Mock<IVersion>();
            Mock<ICollection<IPackage>> stubPackages = new Mock<ICollection<IPackage>>();

            Package package = new Package("name",stubVersion.Object,stubPackages.Object);

            Assert.AreSame(stubPackages.Object,package.Dependencies);
        }

        [Test]
        [TestCase("name")]
        public void GetName_ConstructurShouldSetName_WhenNameIsNotNull(string name)
        {
            Mock<IVersion> stubVersion = new Mock<IVersion>();
            Package package = new Package(name, stubVersion.Object);

            Assert.AreEqual(name,package.Name);
        }

        [Test]
        public void GetVersion_ConstructurShouldSetVersion_WhenVersionIsNotNull()
        {
            Mock<IVersion> stubVersion = new Mock<IVersion>();
            Package package = new Package("name", stubVersion.Object);

            Assert.AreEqual(stubVersion.Object, package.Version);
        }

        [Test]
        public void Constructur_ShouldSetUrl()
        {
            Mock<IVersion> stubVersion = new Mock<IVersion>();
            Package package = new Package("name", stubVersion.Object);

            Assert.IsNotNull(package.Url);
        }

        [Test]
        public void CompareTo_ShouldThrowException_WhenParameterIsNull()
        {
            Mock<IPackage> stubPackage = new Mock<IPackage>();
            Mock<IVersion> stubVersion = new Mock<IVersion>();
            Package package = new Package("name", stubVersion.Object);

            var exc = Assert.Catch<ArgumentNullException>(() => package.CompareTo(null));

            StringAssert.Contains("The object cannot be null",exc.Message);
        }

        [Test]
        public void CompareTo_ShouldThrowException_WhenPackageNameNotTheSameAsCompared()
        {
            Mock<IPackage> stubPackage = new Mock<IPackage>();
            Mock<IVersion> stubVersion = new Mock<IVersion>();
            Package package = new Package("name", stubVersion.Object);
            stubPackage.Setup(p=>p.Name).Returns("other");

            Assert.Throws<ArgumentException>(() => package.CompareTo(stubPackage.Object));          
        }
    }
}
