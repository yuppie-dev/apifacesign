using DinkToPdf;
using DinkToPdf.Contracts;
using Facesign.Services.Application.Interfaces;
using Facesign.Services.Core.Models;
using Facesign.Services.Core.Utility;
using Facesign.Services.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Facesign.Services.Core.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ReportController : Controller
{
    private IConverter _converter;
    private ISignatureRepositoryApp _signatureRepository;
    private readonly ILaudoRepositoryApp _laudoRepositoryApp;
    private readonly IClientsRepository _clientsRepository;

    private readonly IUserRepository _userRepository;
    public ReportController(IConverter converter,
                           ISignatureRepositoryApp signatureRepository,
                           IClientsRepository clientsRepository,
                           ILaudoRepositoryApp laudoRepositoryApp,
                           IUserRepository userRepository)
    {
        _converter = converter;
        _signatureRepository = signatureRepository;
        _laudoRepositoryApp = laudoRepositoryApp;
        _clientsRepository = clientsRepository;
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GenerateByCPF(string cpf)
    {
        var laudoModel = new LaudoModel();

        var user = await _userRepository.Get(cpf);

        if (user == null)
            return BadRequest("Cpf Não encontrado");


        var assinatura = await _signatureRepository.GetSignatureByCpf(cpf);

        if (user.externaldatabaserefid == null)
            return BadRequest("id processo não encontrado");


        var enrollment = await _laudoRepositoryApp.GetEnrollment3D(user.externaldatabaserefid);

        if (assinatura != null)
            laudoModel.FotoId = Convert.ToBase64String(assinatura.image);

        else
            laudoModel.FotoId = enrollment?.data?.auditTrailImage;

        var match3D2D = await _laudoRepositoryApp.GetMatch3D2DIdScan(user.externaldatabaserefid);

        if (match3D2D == null)
            return BadRequest("processo não encontrado - match3D2D");

        laudoModel.Documento = match3D2D?.data?.idScanFrontImage;
        laudoModel.Cpf = user.cpf;
        laudoModel.Device = user.deviceModel;
        laudoModel.MatchLevel = (int)user?.matchLevel;
        laudoModel.Ip = user.ip;
        laudoModel.DataExecucao = user.date_insert.ToString("dd-MM-yyyy HH:mm:ss");


        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Landscape,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10 },
            DocumentTitle = "Laudo Facesign",
            Out = $@"D:\PDFCreator\Laudo_Report_ID-{cpf}_{DateTime.Now.ToString().Replace("/", "-").Replace(" ", "_").Replace(":", "-")}.pdf"
        };
        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = TemplateGenerator.GetHTMLString(laudoModel),
            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Página [page] de [toPage]", Line = true },
            FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
        };
        var pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        _converter.Convert(pdf);

        return Ok("Laudo gerado com sucesso");
    }

    [HttpGet]
    public async Task<IActionResult> GenerateById(Guid id)
    {
        var laudoModel = new LaudoModel();

        var user = await _userRepository.Get(id);

        if (user == null)
            return BadRequest("Cpf Não encontrado");


        var assinatura = await _signatureRepository.GetSignatureByCpf(user.cpf);

        if (user.externaldatabaserefid == null)
            return BadRequest("id processo não encontrado");


        var enrollment = await _laudoRepositoryApp.GetEnrollment3D(user.externaldatabaserefid);

        if (assinatura != null)
            laudoModel.FotoId = Convert.ToBase64String(assinatura.image);

        else
            laudoModel.FotoId = enrollment?.data?.auditTrailImage;

        var match3D2D = await _laudoRepositoryApp.GetMatch3D2DIdScan(user.externaldatabaserefid);

        if (match3D2D == null)
            return BadRequest("processo não encontrado - match3D2D");

        laudoModel.Documento = match3D2D?.data?.idScanFrontImage;
        laudoModel.Cpf = user.cpf;
        laudoModel.Device = user.deviceModel;
        laudoModel.MatchLevel = (int)user?.matchLevel;
        laudoModel.Ip = user.ip;
        laudoModel.DataExecucao = user.date_insert.ToString("dd-MM-yyyy HH:mm:ss");


        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Landscape,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10 },
            DocumentTitle = "Laudo Facesign",
            Out = $@"D:\PDFCreator\Laudo_Report_ID-{user.cpf}_{DateTime.Now.ToString().Replace("/", "-").Replace(" ", "_").Replace(":", "-")}.pdf"
        };
        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = TemplateGenerator.GetHTMLString(laudoModel),
            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Página [page] de [toPage]", Line = true },
            FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
        };
        var pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        _converter.Convert(pdf);

        return Ok("Laudo gerado com sucesso");
    }


    [HttpGet]
    public async Task<IActionResult> GetById(Guid idProcesso)
    {
        var laudo = _signatureRepository.GetSignature(idProcesso);

        //82215a2b-8589-44b0-8311-f11eab9d2516 -- Verde
        //d7267035-27c8-4334-a739-5d5b1caa0c1d -- Antigo
        //29fb3244-9f3c-457c-8dac-883eb329e5f1
        //9e2dfe65-90a7-4d76-9029-fd6cd3be2b39
        var enrollment = await _laudoRepositoryApp.GetEnrollment3D("9e2dfe65-90a7-4d76-9029-fd6cd3be2b39");
        var match3D2D = await _laudoRepositoryApp.GetMatch3D2DIdScan("9e2dfe65-90a7-4d76-9029-fd6cd3be2b39");



        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10 },
            DocumentTitle = "Laudo Facesign",
            Out = $@"D:\PDFCreator\Laudo_Report_ID-{idProcesso}_{DateTime.Now.ToString().Replace("/", "-").Replace(" ", "_").Replace(":", "-")}.pdf"
        };
        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = TemplateGenerator.GetHTMLString(laudo, match3D2D, enrollment),
            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Página [page] de [toPage]", Line = true },
            FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
        };
        var pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        _converter.Convert(pdf);

        return Ok("Successfully created PDF document.");
    }

    [HttpGet]
    public async Task<IActionResult> DownloadById(Guid idProcesso)
    {
        var laudo = _signatureRepository.GetSignature(idProcesso);
        var enrollment = await _laudoRepositoryApp.GetEnrollment3D("d7267035-27c8-4334-a739-5d5b1caa0c1d");
        var match3D2D = await _laudoRepositoryApp.GetMatch3D2DIdScan("d7267035-27c8-4334-a739-5d5b1caa0c1d");

        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
            Margins = new MarginSettings { Top = 10 },
            DocumentTitle = "Laudo Facesign",
        };
        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = TemplateGenerator.GetHTMLString(laudo, match3D2D, enrollment),
            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
            FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
        };
        var pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        var file = _converter.Convert(pdf);

        return File(file, "application/pdf", $"Laudo_Report_ID-{idProcesso}_{DateTime.Now.ToString().Replace(" / ", " - ").Replace(" ", "_").Replace(":", " - ")}.pdf");
    }
}
