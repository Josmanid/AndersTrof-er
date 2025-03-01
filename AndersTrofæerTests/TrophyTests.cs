using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersTrofæer.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        private Trophy trophy;
        [TestInitialize]

        public void Init() {
            //Arrange the default constructor
            trophy = new Trophy();

        }
        [TestMethod()]
        public void TrophyPropCompetitionTest() {

            //Assert

            Assert.AreEqual("Unknown", trophy.Competition);

            Assert.ThrowsException<ArgumentNullException>(
                () => trophy.Competition = null);
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => trophy.Competition = "BO");



        }

        [DataTestMethod()]
        [DataRow(1971)]
        [DataRow(2024)]
        public void TrophyPropYearShouldWorkTest(int validYear) {

            //Act
            Trophy trophyvalid = new Trophy("Unknown", validYear);

            //Assert
            Assert.AreEqual(validYear, trophyvalid.Year);



        }
        [DataTestMethod()]
        [DataRow(1960)]
        [DataRow(2035)]
        [DataRow(1970)]
        [DataRow(2025)]
        public void TrophyPropYearShouldNotWorkTest(int inValidYear) {

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Trophy( "Unknown", inValidYear));


        }

        [TestMethod()]
        public void ToStringTest() {
            //Act
            string result = trophy.ToString();
            //Assert
            Assert.AreEqual(result, $"0 Anders har vundet Unknown i år: 1985");
        }
    }
}