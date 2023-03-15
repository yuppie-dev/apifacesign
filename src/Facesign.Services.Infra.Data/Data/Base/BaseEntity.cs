using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facesign.Services.Infra.Data.Data.Base;

public class BaseEntity
{
    [Key]
    [Column("id")]
    [MaxLength(50)]
    public Guid id { get; set; }

    [Required]
    [Column("date_insert")]
    public DateTime date_insert { get; set; }

}
