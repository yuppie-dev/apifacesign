using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.Laudos;
using Facesign.Services.Entities.Laudos.Enrollment;
using Facesign.Services.Infra.Data.Data;
using MongoDB.Driver;

namespace Facesign.Services.Infra.Data.Repository.Laudos;

public class LaudoRepository : ILaudoRepository
{
    private readonly IDbContext _dbContext;
    public LaudoRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Laudo> GetAllLaudosMongo()
    {
        var collection = _dbContext.GetDatabase().GetCollection<Laudo>("Session");

        //63b6ff62c0e1097423e34ed9
        //63c07e8c259eab4d87a363d2
        //63c4d142e914758ad8dce09f - CNH
        //63d2b89a81179d36a0f852e6 - Pedro

        return await collection.Find(c => c.Id == "63d2b89a81179d36a0f852e6").FirstOrDefaultAsync();
        //return await collection.Find(_ => true).ToListAsync();
    }

    public async Task<Enrollment3D> GetEnrollment3D(string externalDatabaseRefID)
    {
        var collection = _dbContext.GetDatabase().GetCollection<Enrollment3D>("Session");

        return await collection.Find(c => c.externalDatabaseRefID.Contains(externalDatabaseRefID) && c.callData.path == "/enrollment-3d" && c.success == true).FirstOrDefaultAsync();
        //return await collection.Find(c => c.externalDatabaseRefID.Contains(externalDatabaseRefID) && c.callData.path == "/enrollment-3d").FirstOrDefaultAsync();
    }

    public async Task<Laudo> GetMatch3D2DIdScan(string externalDatabaseRefID)
    {
        var collection = _dbContext.GetDatabase().GetCollection<Laudo>("Session");

        return await collection.Find(c => c.externalDatabaseRefID.Contains(externalDatabaseRefID) && c.callData.path == "/match-3d-2d-idscan").FirstOrDefaultAsync();
    }
}
