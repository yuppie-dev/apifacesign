using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Facesign.Services.Entities.Laudos.Enrollment;


public class Enrollment3D
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public Facescansecuritychecks faceScanSecurityChecks { get; set; }
    public int ageEstimateGroupEnumInt { get; set; }
    public string externalDatabaseRefID { get; set; }
    public int retryScreenEnumInt { get; set; }
    public string scanResultBlob { get; set; }
    public bool isLikelyOnFraudList { get; set; }
    public bool isLikelyDuplicate { get; set; }
    public bool enrollForSearchAllUserListResult { get; set; }
    public bool success { get; set; }
    public bool wasProcessed { get; set; }
    public Calldata callData { get; set; }
    public Additionalsessiondata additionalSessionData { get; set; }
    public bool error { get; set; }
    public Serverinfo serverInfo { get; set; }
    public Data data { get; set; }
}

public class Facescansecuritychecks
{
    public bool replayCheckSucceeded { get; set; }
    public bool sessionTokenCheckSucceeded { get; set; }
    public bool auditTrailVerificationCheckSucceeded { get; set; }
    public bool faceScanLivenessCheckSucceeded { get; set; }
}

public class Calldata
{
    public string tid { get; set; }
    public string path { get; set; }
    public DateTime date { get; set; }
    public DateTime updatedDate { get; set; }
    public int epochSecond { get; set; }
    public string requestMethod { get; set; }
}

public class Additionalsessiondata
{
    public bool isAdditionalDataPartiallyIncomplete { get; set; }
    public string platform { get; set; }
    public string appID { get; set; }
    public string installationID { get; set; }
    public string deviceModel { get; set; }
    public string deviceSDKVersion { get; set; }
    public string sessionID { get; set; }
    public string userAgent { get; set; }
    public string ipAddress { get; set; }
}

public class Serverinfo
{
    public string coreServerSDKVersion { get; set; }
    public string customOrStandardServerSDKVersion { get; set; }
    public string type { get; set; }
    public string mode { get; set; }
}

public class Data
{
    public string faceMap { get; set; }
    public string auditTrailImage { get; set; }
    public string lowQualityAuditTrailImage { get; set; }
}


