using Facesign.Services.Entities.Laudos;
using Facesign.Services.Entities.Laudos.Enrollment;

namespace Facesign.Services.Domain.Interfaces.Repository;

public interface ILaudoRepository
{
    Task<Laudo> GetAllLaudosMongo();
    Task<Enrollment3D> GetEnrollment3D(string externalDatabaseRefID);
    Task<Laudo> GetMatch3D2DIdScan(string externalDatabaseRefID);
}
