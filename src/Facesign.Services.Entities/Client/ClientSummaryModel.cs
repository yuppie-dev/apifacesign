
namespace Facesign.Services.Entities.Client
{
    public class ClientSummaryModel : Base
    {
        public string? name { get; set; }

        public string? document { get; set; }

        public string? telephone { get; set; }

        public int? status { get; set; }

        public DateTime? validate { get; set; }
    }
}
