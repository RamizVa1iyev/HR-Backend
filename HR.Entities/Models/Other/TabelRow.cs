using Core.Extensions;
using System.Reflection;

namespace HR.Entities.Models.Other
{
    public class TabelRow
    {
        public string this[int index]
        {
            get
            {
                if (index < 0 | index > 43)
                    throw new IndexOutOfRangeException();

                if (index < 8)
                    return MainData.GetType().GetProperties()[index].GetValue(MainData).ToString();
                else if (index < 39)
                    return Values.Days[index - 7];
                else
                    return AdditionalData.GetType().GetProperties()[index - 38].GetValue(AdditionalData).ToString();
            }
            set
            {
                if (index < 0 | index > 43)
                    throw new IndexOutOfRangeException();

                if (index < 8)
                    MainData.GetType().GetProperties()[index].SetValue(MainData, value);
                else if (index < 39)
                    Values.Days[index - 7] = value;
                else
                    AdditionalData.GetType().GetProperties()[index - 38].SetValue(AdditionalData, value);
            }
        }

        public string this[string key]
        {
            get
            {
                var val1 = MainData.GetType().GetProperties().FirstOrDefault(x => x.Name == key);
                if (val1 != null)
                    return val1.GetValue(MainData).ToString();
                var val2 = AdditionalData.GetType().GetProperties().FirstOrDefault(x => x.Name == key);
                if (val2 != null)
                    return val2.GetValue(AdditionalData).ToString();
                if (int.TryParse(key, out int index))
                    return Values.Days[index - 1];

                throw new KeyNotFoundException();
            }
            set
            {
                var val1 = MainData.GetType().GetProperties().FirstOrDefault(x => x.Name == key);
                if (val1 != null)
                {
                    val1.SetValue(MainData, value);
                    return;
                }
                var val2 = AdditionalData.GetType().GetProperties().FirstOrDefault(x => x.Name == key);
                if (val2 != null)
                {
                    val2.SetValue(AdditionalData, value);
                    return;
                }
                if (int.TryParse(key, out int index))
                {
                    Values.Days[index - 1] = value;
                    return;
                }

                throw new KeyNotFoundException();
            }
        }

        public TabelRow()
        {
            MainData = new TabelMainData();
            Values = new TabelValues();
            AdditionalData = new TabelAdditionalData();
        }

        public TabelRow(TabelMainData mainData, TabelValues values, int overtime)
        {
            MainData = mainData;
            Values = values;
            AdditionalData = new TabelAdditionalData();
            SetAdditional(overtime);
        }

        public TabelMainData MainData { get; set; }
        public TabelValues Values { get; set; }
        public TabelAdditionalData AdditionalData { get; set; }

        public void Show()
        {
            var mprops = MainData.GetType().GetProperties();
            var add = AdditionalData.GetType().GetProperties();

            Print(MainData, mprops);
            foreach (var item in Values.Days)
            {
                Console.Write(item + "-");
            }
            Print(AdditionalData, add);
        }

        private void Print(object core, PropertyInfo[] properties)
        {
            foreach (var prop in properties)
            {
                Console.Write(prop.GetValue(core) + "-");
            }
        }

        private void SetAdditional(int overtime)
        {
            AdditionalData.Overtime = overtime;
            int day = 0, hour = 0, vacation = 0, disease = 0;
            foreach (var item in Values.Days)
            {
                switch (item)
                {
                    case "m":
                        vacation++;
                        break;
                    case "ö/m":
                        vacation++;
                        break;
                    case "x":
                        disease++;
                        break;
                    default:
                        if (item is not null)
                            if (int.TryParse(item.ToString(), out int val))
                            {
                                day++;
                                hour += val;
                            }
                        break;
                }
            }
            AdditionalData.TotalWorkDays = day;
            AdditionalData.TotalWorkHours = hour;
            AdditionalData.VacationDays = vacation;
            AdditionalData.DiseaseDays = disease;
        }
    }
}
