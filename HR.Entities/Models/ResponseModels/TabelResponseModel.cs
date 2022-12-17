using Core.Entities.Abstract;

namespace HR.Entities.Models.ResponseModels
{
    public class TabelResponseModel : IModel
    {
        public TabelResponseModel() { }
        public TabelResponseModel(DateTime forDate, string[,] tabelResult)
        {
            ForDate = forDate;
            TabelResult = tabelResult;
        }

        public DateTime ForDate { get; set; }
        public string[,] TabelResult { get; set; }
    }
}
