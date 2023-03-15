using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facesign.Services.Entities.User
{
    public class TokenModel
    {
        public Guid clientId { get; set; }
        public string name { get; set; }
        public string cpf { get; set; }
        public DateTime dataExp { get; set; }

    }
}
