using MongoDB.Driver;

namespace Facesign.Services.Infra.Data.Data;

public interface IDbContext
{
    IMongoDatabase GetDatabase();
    void Dispose();
}
