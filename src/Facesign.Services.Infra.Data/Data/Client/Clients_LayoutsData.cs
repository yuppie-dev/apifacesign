using Facesign.Services.Entities.Client;
using Facesign.Services.Infra.Data.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facesign.Services.Infra.Data.Data.Client
{
    [Table("clients_layouts")]
    public class Clients_LayoutsData : BaseEntity
    {
        [Column("id_client")]
        [Required]
        public Guid id_client { get; set; }

        [ForeignKey("id_client")]
        public ClientsModel clients { get; set; }

        [Column("primary_color")]
        [StringLength(10)]
        public string? primary_color { get; set; }

        [Column("secundary_color")]
        [StringLength(10)]
        public string? secundary_color { get; set; }

        [Column("home_image")]
        public byte[]? home_image { get; set; }

        [Column("icon")]
        public byte[]? icon { get; set; }  

    }
}
