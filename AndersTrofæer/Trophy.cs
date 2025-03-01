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
        public int Year { get; set; }




    }
}
