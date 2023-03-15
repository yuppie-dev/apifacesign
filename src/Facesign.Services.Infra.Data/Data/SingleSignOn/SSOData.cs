using Facesign.Services.Infra.Data.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facesign.Services.Infra.Data.Data.SingleSignOn
{
    [Table("SSO")]
    public class SSOData : BaseEntity
    {
        [Column("cpf")]
        [StringLength(15)]
        public string? cpf { get; set; }

        [Column("id_client")]
        [Required]
        public Guid id_client { get; set; }
    }
}
