
namespace Facesign.Services.Entities.Facetec.Request
{
    public class EnrollRequest
    {
        public string faceScan { get; set; }

        public string auditTrailImage { get; set; }

        public string lowQualityAuditTrailImage { get; set; }

        public string sessionId { get; set; }

        public string externalDatabaseRefID { get; set; }
    }
}
