using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Yuppie.Services.Infra.Services
{
    public class ZapiService : IZapiService
    {

        public async Task<ZapiResult> sendZap(ZapiModel zapiResponse)
        {


            var key = new KeyRepository().Getkey(new LockID.Entities.Key.KeyModel { application = "AWS" });

            HttpWebRequest HttpReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.z-api.io/instances/{0}/token/{1}/send-text", key.Result.accessKey, key.Result.secretKey));

            HttpReq.ContentType = "application/json";

            HttpReq.Method = "POST";

            byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(zapiResponse));

            HttpReq.ContentLength = data.Length;

            var req_stream = HttpReq.GetRequestStream();

            req_stream.Write(data, 0, data.Length);
            req_stream.Close();

            HttpWebResponse HttpRes = (HttpWebResponse)HttpReq.GetResponse();
            var readStream = new StreamReader(HttpRes.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1"));
            string resp = readStream.ReadToEnd();

            readStream.Close();

            HttpRes.Close();

            return JsonConvert.DeserializeObject<ZapiResult>(resp.Replace("\"{", "{").Replace("}\"", "}").Replace("\\", ""), new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
