
namespace Facesign.Services.Entities.Signature
{
    public class SignatureModel
    {
        public Guid id { get; set; }
        public string cpf { get; set; }
        public Byte[] image { get; set; }
        public int matchLevel { get; set; }
        public string ip { get; set; }
        public string deviceModel { get; set; }

        public string? location { get; set; }


    }
}
