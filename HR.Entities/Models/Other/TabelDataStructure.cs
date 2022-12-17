namespace HR.Entities.Models.Other
{
    // This is demo and currently is in test stage. Please, do not any changes code here.

    public class TabelDataStructure
    {
        private List<TabelRow> _rows;
        public int Count => _rows.Count;

        /// <summary>
        /// Notice :
        /// If index is not in iterval, this will return null.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TabelRow this[int index]
        {
            get
            {
                if (index >= 0 & index < _rows.Count)
                    return _rows[index];
                else
                    return null;
            }
            set
            {
                if (index >= 0 & index < _rows.Count)
                    _rows[index] = value;
            }
        }

        public TabelDataStructure()
        {
            _rows = new List<TabelRow>();
        }

        public TabelDataStructure(List<TabelRow> rows)
        {
            _rows = rows;
        }

        public void Add(TabelRow row) => _rows.Add(row);

        public void Remove(TabelRow row) => _rows.Remove(row);

        public void Clear() => _rows.Clear();

        public void Show()
        {
            foreach (var item in _rows)
            {
                item.Show();
            }
        }


    }
}
