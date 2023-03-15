using Facesign.Services.Core.Models;
using Facesign.Services.Entities.Laudos;
using Facesign.Services.Entities.Laudos.Enrollment;
using Newtonsoft.Json;
using System.Text;

namespace Facesign.Services.Core.Utility;

public class TemplateGenerator
{
    public static string GetHTMLString(LaudoModel laudo)
    {
        var sb = new StringBuilder();
        sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Laudo FaceSign</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>FaceID</th>
                                        <th>Documento</th>
                                        <th>Device</th>
                                        <th>CPF</th>
                                        <th>Data Execução</th>
                                        <th>IP</th>
                                    </tr>");
        //foreach (var laudo in laudos)
        //{
        sb.AppendFormat(@"<tr>
                                    <td><img style='width:130px; height:177px' src='data:image/png;base64, {0} '></></td>
                                    <td><img style='width:281px; height:177px' src='data:image/png;base64, {1} '></></td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>    
                                    <td>{5}</td>    
                                  </tr>", laudo.FotoId, laudo.Documento, laudo.Device, laudo.Cpf, laudo.DataExecucao, laudo.Ip);
        //}
        sb.Append(@"
                                </table>
                            </body>
                        </html>");
        return sb.ToString();
    }



    public static string GetHTMLString(Entities.Signature.SignatureModel laudo, Entities.Laudos.Laudo match3D2D, Enrollment3D laudoMongo)
    {
        var image = Convert.ToBase64String(laudo.image);//laudoMongo.data.lowQualityAuditTrailImage;
        //image = Convert.ToBase64String(laudo.image);
        var img2 = !string.IsNullOrEmpty(match3D2D?.data?.photoIDFrontCrop) ? match3D2D?.data?.photoIDFrontCrop : match3D2D?.data?.idScanFrontImage;
        var device = match3D2D?.additionalSessionData?.deviceModel;

        var doc = "";
        if (match3D2D != null)
        {
            var dados = JsonConvert.DeserializeObject<Ocr>(match3D2D?.ocrResults);

            //TODO: Validar outras formas de buscar
            doc = dados?.ocrResults?.userConfirmed?.groups?
                                     .FirstOrDefault(c => c.groupKey == "idInfo")?.fields
                                     .FirstOrDefault(x => x.uiFieldType.Equals("000.000.000-00"))?.value;

        }

        var sb = new StringBuilder();
        sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Laudo FaceSign</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>FaceID</th>
                                        <th>Documento</th>
                                        <th>Device</th>
                                        <th>CPF</th>                                        
                                        <th>IP</th>
                                    </tr>");
        //foreach (var laudo in laudos)
        //{
        sb.AppendFormat(@"<tr>
                                    <td><img style='width:130px; height:177px' src='data:image/png;base64, {0} '></></td>
                                    <td><img style='width:281px; height:177px' src='data:image/png;base64, {1} '></></td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>    
                                  </tr>", image, img2, laudo.deviceModel, laudo.cpf, laudo.ip);
        //}
        sb.Append(@"
                                </table>
                            </body>
                        </html>");
        return sb.ToString();
    }
}
