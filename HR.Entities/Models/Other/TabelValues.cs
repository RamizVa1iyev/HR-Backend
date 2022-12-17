namespace HR.Entities.Models.Other
{
    public class TabelValues
    {
        public string this[int index]
        {
            get
            {
                return Days[index];
            }
            set
            {
                Days[index] = value;
            }
        }
        public TabelValues() 
        {
            Days = new string[31];
        }

        public string[] Days { get; set; }

        public void SetAll(string value)
        {
            for (int i = 0; i < Days.Length; i++)
            {
                Days[i] = value;
            }
        }

        public void SetAll(int start, int end, string value)
        {
            for (int i = start; i < end; i++)
            {
                Days[i] = value;
            }
        }
    }
}
