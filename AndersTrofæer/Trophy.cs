using System.Xml.Linq;

namespace AndersTrofæer
{
    public class Trophy
    {
       
        private string? _competition;
        private int _year;
        public int Id { get; set; }
        public string? Competition
        {

            get => _competition;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Must have a competition name");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("The competition name must be atleast 3 character long");
                }
                _competition = value;

            }

        }
        public int Year
        {
            get => _year;
            set
            {
                if (value <= 1970 || value >= 2025)
                {
                    throw new ArgumentOutOfRangeException($"The year should be more than 1970 and smaller than 2025");
                }
                _year = value;
            }

        }
        //Paramatiserede constructor så vi kan fylde lidt på
        public Trophy(string competition, int year)
        {
            
            Competition = competition;
            Year = year;
        }
        //Default constructor så vi kan få nogle værdier uden at tænke
        public Trophy()
        {
            Id = 0;
            Competition = "Unknown";
            Year = 1985;
        }
      
        public override string ToString() {
            return $"{Id} Anders har vundet {Competition} i år: {Year}";
        }

    }
}
