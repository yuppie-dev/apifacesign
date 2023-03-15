using Facesign.Services.Domain.Interfaces;
//using iText.IO.Font.Constants;
//using iText.Kernel.Font;
//using iText.Kernel.Geom;
//using iText.Kernel.Pdf;
//using iText.Layout.Element;
//using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Facesign.Services.Domain.PDF
{
    public class PDFGenerator : IPdfGenerator
    {

        public string GeneratorPdfSignature(Guid id)
        {
            //using (PdfWriter wpdf = new PdfWriter("", new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            //{
            //    var pdf = new PdfDocument(wpdf);

            //    var document = new iText.Layout.Document(pdf, PageSize.A4);

            //    Table table = new Table(UnitValue.CreatePercentArray(12)).UseAllAvailableWidth();

            //    //CABECALHO PRINCIPAL
            //    setCabecalho(table, "TERMO DE RESICAO DO CONTRATO DE TRABALHO", true);

            //    table.AddCell(new Cell(1, 12)
            //        .SetTextAlignment(TextAlignment.LEFT)
            //        .Add(new Paragraph(string.Format("Nome do Empregado: {0}", "NOME DO FUNCIONARIO")).SetFontSize(8))
            //        );

            //    //DADOS FUNCIONARIO

            //    table.AddCell(new Cell(1, 6).Add(new Paragraph(string.Format("CTPS Nº/Série: {0}", "NUMERO DA CARTEIRA")).SetFontSize(8)));
            //    table.AddCell(new Cell(1, 6).Add(new Paragraph(string.Format("Depto:")).SetFontSize(8)));
            //    table.AddCell(new Cell(1, 12).Add(new Paragraph(string.Format("Período aquisitivo: {0} a {1}", "20/01/2021", "20/01/2022")).SetFontSize(8)));
            //    table.AddCell(new Cell(1, 6).Add(new Paragraph(string.Format("Período de gozo: {0} a {1}", "06/10/2021", "25/10/2021")).SetFontSize(8)));
            //    table.AddCell(new Cell(1, 6).Add(new Paragraph(string.Format("Período de Abono Pecuniário: {0} a {1}", "06/10/2021", "25/10/2021")).SetFontSize(8)));

            //    //CALCULO REMUNERAÇÃO
            //    setCabecalho(table, "CALCULO DA REMUNERAÇÃO BASE PARA PAGAMENTO DE FÉRIAS", false);


            //}

            return "";

        }

       // private void setCabecalho(Table table, string cabecalho, bool principal)
       // {
            //var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            //if (principal)
            //{
            //    table.AddHeaderCell(new Cell(1, 12).Add(new Paragraph(cabecalho)
            //         .SetFont(font)
            //         .SetFontSize(10)
            //         .SetPadding(5)
            //         .SetTextAlignment(TextAlignment.CENTER)));
            //}
            //else
            //{
            //    table.AddCell(new Cell(1, 12).Add(new Paragraph(cabecalho)
            //         .SetFont(font)
            //         .SetFontSize(10)
            //         .SetPadding(5)
            //         .SetTextAlignment(TextAlignment.CENTER)));
            //}

       // }
    }
}
