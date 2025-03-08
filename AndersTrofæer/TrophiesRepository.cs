using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndersTrofæer
{
    public class TrophiesRepository
    {
        //Vil altid blive initialiserede en ny liste
        private List<Trophy> trophies { get; set; } = new List<Trophy>();
        private int NextId = 1;


        public IEnumerable<Trophy> Get(string? competition = null, int? yearBefore = null) {
            //Her Returneres en kopi af listen af alle Trophy objekter
            IEnumerable<Trophy> result = new List<Trophy>(trophies);
            //Filter efter år
            if (yearBefore != null)
            {
                result = result.Where(y => y.Year < yearBefore);
            }
            // sorter i alfabetisk rækkefælge ascending og vær incase sensitiv
            result = result.OrderBy(x => x.Competition, StringComparer.OrdinalIgnoreCase);


            return result;

        }
        public Trophy GetById(int id) {

            return trophies.FirstOrDefault(trophy => trophy.Id == id);
        }

        public Trophy Add(Trophy trophy) {
            trophy.Id = NextId++;
            trophies.Add(trophy);
            return trophy;

        }

        public Trophy Remove(int id) {
            Trophy trophy = GetById(id);
            if (trophy == null)
            {
                throw new ArgumentNullException("Trophy with the specified ID does not exist!");
            }
            trophies.Remove(trophy);
            return trophy;
        }

        public Trophy Update(int id, Trophy trophy) {
            Trophy existingtrophy = GetById(id);
            if (existingtrophy == null)
            {
                throw new ArgumentNullException("Trophy with the specified ID does not exist!");
            }
            existingtrophy.Competition = trophy.Competition;
            existingtrophy.Year = trophy.Year;
            return existingtrophy;
        }


    }
}
