using Facesign.Services.Entities.Client;
using Facesign.Services.Infra.Data.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facesign.Services.Infra.Data.Data.Client
{
    [Table("clients_functionalities")]
    public class Clients_FunctionalitiesData : BaseEntity
    {
        [Column("id_client")]
        [Required]
        public Guid id_client { get; set; }

        [ForeignKey("id_client")]
        public virtual ClientsModel client { get; set; }
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
