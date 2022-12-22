using Core.Entities.Abstract;

namespace HR.Entities.Models.ResponseModels
{
    public class TabelResponseModel : IModel
    {
        public TabelResponseModel() 
        {
            Rows = new List<TabelResponseRow>();
        }

        public TabelResponseModel(DateTime forDate, List<TabelResponseRow> rows)
        {
            ForDate = forDate;
            Rows = rows;
        }

        public DateTime ForDate { get; set; }
        public List<TabelResponseRow> Rows { get; set; }
    }
}
