using Microsoft.VisualStudio.TestTools.UnitTesting;
using AndersTrofæer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AndersTrofæer.Tests
{

    [TestClass()]
    public class TrophiesRepositoryTests
    {
        private TrophiesRepository _trophy;
        [TestInitialize]

        public void Init() {
            //Arrange 
            _trophy = new TrophiesRepository();
            _trophy.Add(new Trophy() { Competition = "Bowling", Year = 1997 });
            _trophy.Add(new Trophy() { Competition = "Cykling", Year = 1995 });
            _trophy.Add(new Trophy() { Competition = "StangSpring", Year = 2005 });
            _trophy.Add(new Trophy() { Competition = "FaldskærmUdspring", Year = 2003 });
            _trophy.Add(new Trophy() { Competition = "PolkaDans", Year = 2020 });
        }


        [TestMethod()]
        public void AddTest() {

            Trophy trophy = new Trophy();
            _trophy.Add(trophy);
            //Er id nu 6??
            Assert.AreEqual(6, trophy.Id);
            // er der 6 elementer i alt?
            Assert.AreEqual(6, _trophy.Get().Count());
        }

        [TestMethod()]
        public void RemoveTest() {

            int idToRemove = _trophy.Get().Last().Id;
            _trophy.Remove(idToRemove);
            // er der 4 elementer i alt?
            Assert.AreEqual(4, _trophy.Get().Count());
            //Bliver der kastet en exception hvis jeg sletter noget der ikke er på listen??
            Assert.ThrowsException<ArgumentNullException>(
                () => _trophy.Remove(999));
        }

        [TestMethod]
        public void UpdateTest() {
            var trophies = _trophy.Get().ToList();
            var firstTrophy = trophies[0]; // vi henter vores første trofæ

            //Hele ideen er at bevare id
            Trophy UpdatedTrophy = new Trophy(competition: "Boksning", year: 2012);
            _trophy.Update(firstTrophy.Id, UpdatedTrophy);

            Trophy retrievedTrophy = _trophy.GetById(firstTrophy.Id);

            //Assert
            Assert.AreEqual("Boksning", retrievedTrophy.Competition);
            Assert.AreEqual(2012, retrievedTrophy.Year);
            Assert.AreEqual(retrievedTrophy.Id, firstTrophy.Id);

            Assert.ThrowsException<ArgumentNullException>(
           () => _trophy.Update(999, _trophy.Get().Last()));
        }
        [TestMethod]
        public void FiltersCorrectlyTest() {
            //Act
            IEnumerable<Trophy> YearNoFilter = _trophy.Get();
            // Hvor mange trofæer har vi før 1998?
            IEnumerable<Trophy> yearWithFilter = _trophy.Get(yearBefore: 1998);
            //Assert
            Assert.AreEqual(5, YearNoFilter.Count());
            Assert.AreEqual(2, yearWithFilter.Count());
        }

        [TestMethod]
        public void SortsByCompetitionTest() {
            //act
            IEnumerable<Trophy> SortTrophyAsc = _trophy.Get(competition:"b");

            //Assert
            Assert.AreEqual("Bowling", SortTrophyAsc.ElementAt(0).Competition);
            Assert.AreEqual("Cykling", SortTrophyAsc.ElementAt(1).Competition);
            Assert.AreEqual("FaldskærmUdspring", SortTrophyAsc.ElementAt(2).Competition);
            Assert.AreEqual("PolkaDans", SortTrophyAsc.ElementAt(3).Competition);
            Assert.AreEqual("StangSpring", SortTrophyAsc.ElementAt(4).Competition);


        }
    }
}