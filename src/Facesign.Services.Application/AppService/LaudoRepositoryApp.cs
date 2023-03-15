using Facesign.Services.Application.Interfaces;
using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.Laudos;
using Facesign.Services.Entities.Laudos.Enrollment;

namespace Facesign.Services.Application.AppService;

public class LaudoRepositoryApp : ILaudoRepositoryApp
{
    private readonly ILaudoRepository _laudoRepository;

    public LaudoRepositoryApp(ILaudoRepository laudoRepository)
    {
        _laudoRepository = laudoRepository;
    }
    public Task<Laudo> GetAllLaudosMongo()
    {
        return _laudoRepository.GetAllLaudosMongo();
    }

    public Task<Enrollment3D> GetEnrollment3D(string externalDatabaseRefID)
    {
        return _laudoRepository.GetEnrollment3D(externalDatabaseRefID);
    }

    public Task<Laudo> GetMatch3D2DIdScan(string externalDatabaseRefID)
    {
        return _laudoRepository.GetMatch3D2DIdScan(externalDatabaseRefID);
    }
}
