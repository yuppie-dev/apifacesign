
namespace Facesign.Services.Entities.Configuration
{
    public static class BuildConfigurationModel
    {
        public static string ConnectionString { get; set; }
        public static string EndpointFrontEnd { get; set; }

        public static string EndpointSDK { get; set; }

        public static string? MongoConnectionString { get; set; }
    }
}
