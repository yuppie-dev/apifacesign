
namespace Facesign.Services.Entities.Client
{

    public class ClientsLayoutsModel : Base
    {
        public Guid id_client { get; set; }

        public string? primary_color { get; set; }

        public string? secundary_color { get; set; }

        public string? home_image { get; set; }

        public string? icon { get; set; }

    }
}
