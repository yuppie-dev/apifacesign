using Facesign.Services.Infra.Data.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Facesign.Services.Infra.Data.Data.User
{
    [Table("Users")]
    public class UserData : BaseEntity
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
       

        [Column("matchLevel")]
        public int? matchLevel { get; set; }

        [Column("externaldatabaserefid")]
        public string? externaldatabaserefid { get; set; }

        [Column("ip")]
        public string? ip { get; set; }

        [Column("deviceModel")]
        public string? deviceModel { get; set; }

        [Column("location")]
        public string? location { get; set; }
    }
}
