namespace HR.Entities.Models.ResponseModels
{
    public class SalaryResponseModel
    {
        public SalaryResponseModel() 
        {
            Rows = new List<SalaryResponseRow>();
        }
        public SalaryResponseModel(DateTime forDate, List<SalaryResponseRow> rows)
        {
            ForDate = forDate;
            Rows = rows;
        }

        public DateTime ForDate { get; set; }
        public List<SalaryResponseRow> Rows { get; set; }
    }
}
