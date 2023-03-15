using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facesign.Services.Entities.Facetec.Request
{
    public class matchModelRequest
    {
        public string auditTrailImage { get; set; }
        public string externalDatabaseRefID { get; set; }
        public string faceScan { get; set; }
        public string lowQualityAuditTrailImage { get; set; }
        public string sessionId { get; set; }       

    }
}
