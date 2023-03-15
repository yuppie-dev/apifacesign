using Facesign.Services.Infra.Data.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Facesign.Services.Infra.Data.Data.Signature
{
    [Table("Signatures")]
    public class SignaturesData : BaseEntity
    {     

        [Column("name")]
        [StringLength(150)]        
        public string? name { get; set; }

        [Column("cpf")]
        [StringLength(150)]        
        public string? cpf { get; set; }


        [Column("image")]
        [StringLength(13)]
        public byte[]? image { get; set; }


        [Column("status")]        
        public int status { get; set; }

        [Column("validate")]
        public DateTime validate { get; set; }

        [Column("dataSignature")]
        public DateTime? dataSignature { get; set; }

        [Column("matchLevel")]
        public int? matchLevel { get; set; }

        [Column("ip")]
        public string? ip { get; set; }

        [Column("deviceModel")]
        public string? deviceModel { get; set; }

        [Column("location")]
        public string? location { get; set; }
    }
}
