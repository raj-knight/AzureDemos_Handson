// https://docs.microsoft.com/en-us/rest/api/eventhub/generate-sas-token#powershell

using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web;

Console.WriteLine("Authorization key for post man to post msgs to Event Hub");

// dev
var sasToken =
    createToken(
    resourceUri: "https://eh-set-dev-dach-tbd-a.servicebus.windows.net/pdcpartinventory/messages",
    keyName: "publish",
    key: "kkgPqd93mmvNxVxWumDJcxIyfvJVLoQpp8k6v2ca84c="
    );

// uat
/*var sasToken =
    createToken(
    resourceUri: "https://eh-set-uat-dach-tbd-a.servicebus.windows.net/partcatalog/messages",
    keyName: "publish",
    key: "Hsk2n7xYC0Kj9haiqwkaGcQ/84q9BDVeBz2FRxn6K+8="
    );*/

Console.WriteLine("Content-Type: application/atom+xml;type=entry;charset=utf-8");


Console.WriteLine("Authorization: " + sasToken);


static string createToken(string resourceUri, string keyName, string key)
{
    TimeSpan sinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1);
    var week = 60 * 60 * 24 * 7;
    var expiry = Convert.ToString((int)sinceEpoch.TotalSeconds + week);
    string stringToSign = HttpUtility.UrlEncode(resourceUri) + "\n" + expiry;
    HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
    var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
    var sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}", HttpUtility.UrlEncode(resourceUri), HttpUtility.UrlEncode(signature), expiry, keyName);
    return sasToken;
}
