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
    class ProjectTest
    {
        [Test]
        public void Constructor_ParameterNullName_ExpectedException()
        {
            Assert.Throws<ArgumentNullException>(() => new Project(null, "loc"));
        }
        [TestCase("name")]
        public void NameField_ConstructorSetName_CorrectNameField(string name)
        {
            Project pro = new Project(name,"loc");
            Assert.AreEqual(name, pro.Name);
        }

        [Test]
        public void Constructor_ParameterNullLocation_ExpectedException()
        {
            Assert.Throws<ArgumentNullException>(() => new Project("name",null));
        }

        [TestCase("location")]
        public void LocationField_ConstructorSetLocation_CorrectLocationField(string location)
        {
            Project pr = new Project("name",location);
            Assert.AreEqual(location,pr.Location);
        }

    }
}
