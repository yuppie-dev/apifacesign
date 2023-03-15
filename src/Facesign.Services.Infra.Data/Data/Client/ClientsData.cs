using Facesign.Services.Infra.Data.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facesign.Services.Infra.Data.Data.Client
{
    [Table("clients")]
    public class ClientsData : BaseEntity
    {
        [Column("name")]
        [StringLength(150)]
        [Required]
        public string? name { get; set; }

        [Column("cpf")]
        [StringLength(15)]
        public string? cpf { get; set; }

        [Column("telephone")]
        [StringLength(13)]

        public string? telephone { get; set; }

        [Column("status")]
        public int? status { get; set; }

        [Column("validate")]
        public DateTime? validate { get; set; }
    }
}
