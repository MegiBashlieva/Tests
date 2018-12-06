using NUnit.Framework;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.UnitTests.Models
{
    [TestFixture]
    class PackageVersionTest
    {
        [Test]
        public void SetMajor_ShouldThrowException_WhenCreatePackageVersion()
        {
            Assert.Throws<ArgumentException>(() => new PackageVersion(-1, 0, 0, 0));
        }

        [Test]
        public void GetMajor_ShouldReturnCorrectValue_WhenCreatePackageVersion()
        {
            PackageVersion packVer = new PackageVersion(0, 0, 0, 0);
            Assert.AreEqual(0,packVer.Major);
        }

        [Test]
        public void SetMinor_ShouldThrowException_WhenCreatePackageVersion()
        {
            Assert.Throws<ArgumentException>(() => new PackageVersion(0, -1, 0, 0));
        }

        [Test]
        public void GetMinor_ShouldReturnCorrectValue_WhenCreatePackageVersion()
        {
            PackageVersion packVer = new PackageVersion(0, 0, 0, 0);
            Assert.AreEqual(0, packVer.Minor);
        }

        [Test]
        public void SetPatch_ShouldThrowException_WhenCreatePackageVersion()
        {
            Assert.Throws<ArgumentException>(() => new PackageVersion(0, 0, -1, 0));
        }

        [Test]
        public void GetPatch_ShouldReturnCorrectValue_WhenCreatePackageVersion()
        {
            PackageVersion packVer = new PackageVersion(0, 0, 0, 0);
            Assert.AreEqual(0, packVer.Patch);
        }

        //[Test] How to test enum values?
        //public void SetVersionType_ShouldThrowException_WhenCreatePackageVersion()
        //{
        //    Assert.Throws<ArgumentException>(() => new PackageVersion(0, 0, 0, Enums.VersionType.));
        //}

        //[Test]
        //public void GetVersionType_ShouldReturnCorrectValue_WhenCreatePackageVersion()
        //{
        //    PackageVersion packVer = new PackageVersion(0, 0, 0, 0);
        //    Assert.AreEqual(0, packVer.VersionType.);
        //}
    }
}
