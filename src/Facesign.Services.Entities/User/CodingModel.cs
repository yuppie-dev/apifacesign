
namespace Facesign.Services.Entities.User
{
    public class UserModel 
    {
        public Guid id { get; set; }

        public DateTime date_insert { get; set; }

        public string? name { get; set; }

        public string? cpf { get; set; }

        public string? telephone { get; set; }

        public int? matchLevel { get; set; }

        public string? ip { get; set; }

        public int? status { get; set; }

        public string? deviceModel { get; set; }

        public string? externaldatabaserefid { get; set; }

        public string? location { get; set; }        
    }
}
