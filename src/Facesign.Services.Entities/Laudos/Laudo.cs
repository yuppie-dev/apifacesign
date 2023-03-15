using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facesign.Services.Entities.Laudos;


public class Laudo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public int idScanAgeEstimateGroupEnumInt { get; set; }
    public string externalDatabaseRefID { get; set; }
    public int matchLevel { get; set; }
    public int fullIDStatusEnumInt { get; set; }
    public int digitalIDSpoofStatusEnumInt { get; set; }
    public string scanResultBlob { get; set; }
    public string ocrResults { get; set; }
    public string documentData { get; set; }
    public int nfcStatusEnumInt { get; set; }
    public int nfcAuthenticationStatusEnumInt { get; set; }
    public int barcodeStatusEnumInt { get; set; }
    public int mrzStatusEnumInt { get; set; }
    public int faceOnDocumentStatusEnumInt { get; set; }
    public int textOnDocumentStatusEnumInt { get; set; }
    public int matchLevelNFCToFaceMap { get; set; }
    public bool isCompletelyDone { get; set; }
    public bool isIDScanIncomplete { get; set; }
    public bool isReadyForUserConfirmation { get; set; }
    public bool didCompleteIDScanWithoutMatchingOCRTemplate { get; set; }
    public bool didMatchIDScanToOCRTemplate { get; set; }
    public bool scannedIDPhotoFaceFoundWithMinimumQuality { get; set; }
    public bool unexpectedMediaEncounteredAtLeastOnce { get; set; }
    public int photoIDNextStepEnumInt { get; set; }
    public bool success { get; set; }
    public bool wasProcessed { get; set; }
    public Calldata callData { get; set; }
    public Additionalsessiondata additionalSessionData { get; set; }
    public bool error { get; set; }
    public Serverinfo serverInfo { get; set; }
    public Data data { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    public string enrollmentSession { get; set; }
    public string idScanSessionId { get; set; }
    public bool didCompleteIDScanWithUnexpectedMedia { get; set; }
    public bool didCompleteIDScanWithoutMatching { get; set; }
}

public class Calldata
{
    public string tid { get; set; }
    public string path { get; set; }
    public DateTime date { get; set; }
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
    public string idScan { get; set; }
    public string idScanFrontImage { get; set; }
    public string idScanBackImage { get; set; }
    public string photoIDBackCrop { get; set; }
    public string photoIDFrontCrop { get; set; }
    public string photoIDFaceCrop { get; set; }
    public string photoIDPrimarySignatureCrop { get; set; }
    public string photoIDSecondarySignatureCrop { get; set; }
    public string extractedNFCImage { get; set; }
    public Autoextractedocrdata autoExtractedOCRData { get; set; }
    public Userconfirmedextracteddata userConfirmedExtractedData { get; set; }
    public Templateinfo templateInfo { get; set; }
    public string photoIDTamperingEvidenceFrontImage { get; set; }
    public string photoIDTamperingEvidenceBackImage { get; set; }
}

public class Autoextractedocrdata
{
    public string dateOfExpiration { get; set; }
    public string dateOfIssue { get; set; }
    public string dateOfBirth { get; set; }
    public string customField1 { get; set; }
    public string placeOfBirth { get; set; }
    public string idNumber { get; set; }
}

public class Userconfirmedextracteddata
{
    public string dateOfExpiration { get; set; }
    public string dateOfIssue { get; set; }
    public string dateOfBirth { get; set; }
    public string placeOfBirth { get; set; }
    public string customField1 { get; set; }
    public string idNumber { get; set; }
}

public class Templateinfo
{
    public string templateName { get; set; }
    public string templateType { get; set; }
}


//OCR

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Field
{
    public string fieldKey { get; set; }
    public string uiFieldType { get; set; }
    public string value { get; set; }
}

public class Group
{
    public List<Field> fields { get; set; }
    public string groupFriendlyName { get; set; }
    public string groupKey { get; set; }
}

public class OcrResults
{
    public Scanned scanned { get; set; }
    public string templateName { get; set; }
    public string templateType { get; set; }
    public UserConfirmed userConfirmed { get; set; }
}

public class Ocr
{
    public OcrResults ocrResults { get; set; }
}

public class Scanned
{
    public List<Group> groups { get; set; }
}

public class UserConfirmed
{
    public List<Group> groups { get; set; }
}

