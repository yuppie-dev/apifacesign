using Facesign.Services.Entities.Configuration;

namespace Facesign.Services.Infra.Data.Core
{
    public class Database
    {
        public string IniciaConexao()
        {
            //hom fortal
            //var connectionString = "U2VydmVyPVlVUFBJRS1TUlYwMTtJbml0aWFsIENhdGFsb2c9TG9ja0lEO1BlcnNpc3QgU2VjdXJpdHkgSW5mbz1GYWxzZTtVc2VyIElEPXVzZXJfbG9ja0lEOyBQYXNzd29yZD15dXBwaWVAMjAyMjsgUG9vbGluZz1GYWxzZTtNdWx0aXBsZUFjdGl2ZVJlc3VsdFNldHM9RmFsc2U7RW5jcnlwdD1GYWxzZTtUcnVzdFNlcnZlckNlcnRpZmljYXRlPUZhbHNl";

            //localhost
            // var connectionString = "U2VydmVyPURFU0tUT1AtMFFDVjdRRVxTUUxFWFBSRVNTO0luaXRpYWwgQ2F0YWxvZz1ZdXBwaWU7UGVyc2lzdCBTZWN1cml0eSBJbmZvPUZhbHNlO1VzZXIgSUQ9dXNlcl95dXBwaWU7IFBhc3N3b3JkPXl1cHBpZUA7IFBvb2xpbmc9RmFsc2U7TXVsdGlwbGVBY3RpdmVSZXN1bHRTZXRzPUZhbHNlO0VuY3J5cHQ9RmFsc2U7VHJ1c3RTZXJ2ZXJDZXJ0aWZpY2F0ZT1GYWxzZQ==";
            // return new SqlConnection(new Base64Crypt().Decrypt(BuildConfigurationModel.ConnectionString));
            return BuildConfigurationModel.ConnectionString;
           
        }

       
    }
}
