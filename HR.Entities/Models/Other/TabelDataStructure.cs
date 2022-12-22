using Core.Extensions;
using HR.Entities.Concrete;
using HR.Entities.Models.ResponseModels;

namespace HR.Entities.Models.Other
{
    // This is demo and currently is in test stage. Please, do not any changes code here.

    public class TabelDataStructure
    {
        private List<TabelRow> _rows;
        public int Count => _rows.Count;
        public DateTime ForDate { get; set; }

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

        public void AddRange(IEnumerable<TabelRow> rows) => _rows.AddRange(rows);

        public void Remove(TabelRow row) => _rows.Remove(row);

        public void Clear() => _rows.Clear();

        public void Show()
        {
            foreach (var item in _rows)
            {
                item.Show();
            }
        }

        public void SetAll(string value)
        {
            foreach (var item in _rows)
            {
                item.Values.SetAll(value);
            }
        }

        public void SetAll(int start, int end, string value)
        {
            foreach (var item in _rows)
            {
                item.Values.SetAll(start, end, value);
            }
        }

        public void SetDays(List<CalendarDay> days)
        {
            foreach (var item in _rows)
            {
                foreach (var day in days)
                {
                    switch (day.DayType)
                    {
                        case Entities.Constants.DayTypes.RestDay:
                            item.Values.SetAll(day.Date.Day, day.Date.Day, "i");
                            break;
                        case Entities.Constants.DayTypes.Holiday:
                            item.Values.SetAll(day.Date.Day, day.Date.Day, "b");
                            break;
                        case Entities.Constants.DayTypes.Mourning:
                            item.Values.SetAll(day.Date.Day, day.Date.Day, "h");
                            break;
                    }
                }
            }
        }

        public void SetVacations(List<EmployeeModel> mainData)
        {
            foreach (var row in _rows)
            {
                var data = mainData.First(d => d.EmployeeId == row.MainData.EmployeeId);
                foreach (var item in data.Vacations)
                {
                    row.Values.SetAll(item.StartDate.Day, item.EndDate.Day, item.VacationType == 1 ? "ö/m" : "m");
                }
            }
        }

        public void SetDiseases(List<EmployeeModel> mainData)
        {
            foreach (var row in _rows)
            {
                var data = mainData.First(d => d.EmployeeId == row.MainData.EmployeeId);
                foreach (var item in data.Bulletens)
                {
                    row.Values.SetAll(item.StartDate.Day, item.EndDate.Day, "x");
                }
            }
        }

        public void SetPermissions(List<EmployeeModel> mainData)
        {
            foreach (var row in _rows)
            {
                var data = mainData.First(p => p.EmployeeId == row.MainData.EmployeeId);
                foreach (var item in data.Permissions)
                {
                    switch (item.PermissionType)
                    {
                        case Entities.Constants.PermissionTypes.Hour:
                            var value = row[item.StartDate.Day.ToString()].ToInt();
                            if (value == 0)
                                continue;
                            row.Values.SetAll(item.StartDate.Day, item.EndDate.Day, (value - item.Count).ToString());
                            break;
                        case Entities.Constants.PermissionTypes.Day:
                            row.Values.SetAll(item.StartDate.Day, item.EndDate.Day, "i/g");
                            break;
                    }
                }
            }
        }

        public void SetRecruitmentResignation(List<EmployeeModel> mainData)
        {
            var first = new DateTime(ForDate.Year, ForDate.Month, 1);
            var last = first.AddMonths(1).AddDays(-1);

            foreach (var row in _rows)
            {
                var data = mainData.First(d => d.EmployeeId == row.MainData.EmployeeId).Contract;
                if (data.ContractStartDate > first)
                    row.Values.SetAll(1, data.ContractStartDate.Day, "");
                if (data.ContractEndDate < last)
                    row.Values.SetAll(data.ContractEndDate.Day + 1, 31, "");
            }
        }

        public void Prepare(List<CalendarDay> days, List<EmployeeModel> mainData)
        {
            SetDays(days);
            SetPermissions(mainData);
            SetVacations(mainData);
            SetDiseases(mainData);
            SetRecruitmentResignation(mainData);
        }

        public TabelResponseModel Export()
        {
            var result = new TabelResponseModel
            {
                ForDate = ForDate
            };

            foreach (var item in _rows)
            {
                var newRow = new TabelResponseRow(item.MainData.No, item.MainData.Name, item.MainData.Surname, item.MainData.FatherName,
                    item.MainData.Salary, item.MainData.Duty, item.MainData.State, item.Values.Days.ToList(), item.AdditionalData.TotalWorkDays,
                    item.AdditionalData.TotalWorkHours, item.AdditionalData.VacationDays, item.AdditionalData.DiseaseDays, item.AdditionalData.Overtime);
                result.Rows.Add(newRow);
            }

            return result;
        }
    }
}
