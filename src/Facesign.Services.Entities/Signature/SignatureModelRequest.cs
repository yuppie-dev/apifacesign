
namespace Facesign.Services.Entities.Signature
{
    public class SignatureModelRequest
    {
        public Guid id { get; set; }
        // public string name { get; set; }
        public string cpf { get; set; }
        public string image { get; set; }
       // public string CNHImage { get; set; }
       
        public int matchLevel { get; set; }
        public string ip { get; set; }

        public string deviceModel { get; set; }

        public string location { get; set; }
    }
}
