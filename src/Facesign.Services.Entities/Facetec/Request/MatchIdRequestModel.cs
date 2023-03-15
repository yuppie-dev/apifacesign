using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facesign.Services.Entities.Facetec.Request
{
    public class MatchIdRequestModel
    {
        public string idScan { get; set; }
        public string sessionId { get; set; }
        public string externalDatabaseRefID { get; set; }
        public int minMatchLevel { get; set; }
        public string idScanFrontImage { get; set; }
    }
}
