
namespace Facesign.Services.Entities.Client
{
    public class ClientsFunctionalitiesModel : Base
    {
        public Guid id_client { get; set; }
        public bool match_3d { get; set; }
        public bool liveness_3d { get; set; }
        public bool liveness_2d { get; set; }
        public bool authenticate_cnh { get; set; }
        public bool serpro { get; set; }
        public bool sso { get; set; }
        public string url_redirect { get; set; }
        public string chave { get; set; }
    }
}
