using Facesign.Services.Application.Interfaces;
using Facesign.Services.Domain.Interfaces;


namespace Facesign.Services.Application.AppService
{
    public class PdfGeneratorApp : IPdfGeneratorApp
    {
        IPdfGenerator _Pdf;
        public PdfGeneratorApp(IPdfGenerator pdfGenerator)
        {
            _Pdf = pdfGenerator;
        }

        public string GeneratorPdfSignature(Guid id)
        {
            return _Pdf.GeneratorPdfSignature(id);
        }
    }
}
