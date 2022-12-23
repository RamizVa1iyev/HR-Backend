using HR.Entities.Models.ResponseModels;

namespace HR.Entities.Models.Other.Salary
{
    public class SalaryDataStructure
    {
        private List<SalaryRow> _rows;

        public int Count => _rows.Count;

        public DateTime ForDate { get; set; }

        public SalaryRow this[int index]
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

        public SalaryDataStructure()
        {
            _rows = new List<SalaryRow>();
        }

        public SalaryDataStructure(List<SalaryRow> rows)
        {
            _rows = rows;
        }

        public void Add(SalaryRow row) => _rows.Add(row);

        public void AddRange(IEnumerable<SalaryRow> rows) => _rows.AddRange(rows);

        public void Remove(SalaryRow row) => _rows.Remove(row);

        public void Clear() => _rows.Clear();

        public SalaryResponseModel Export()
        {
            var result = new SalaryResponseModel
            {
                ForDate = ForDate
            };

            foreach (var item in _rows)
            {
                var newRow = new SalaryResponseRow(item.No, item.Name, item.Surname, item.FatherName, item.Duty, item.Salary, item.TotalWorkHours,
                                                    item.WorkHours, item.ComputedSalary, item.Reward, item.Vacation, item.SumSalary, item.IncomingTax,
                                                    item.PensionFond, item.ISH, item.ITSH, item.TotalTax, item.ValueToPaid);
                result.Rows.Add(newRow);
            }
            return result;
        }
    }
}
