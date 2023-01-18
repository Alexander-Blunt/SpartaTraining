using Newtonsoft.Json.Linq;
using System.Net;

namespace APIClientApp.PostcodesIOService;

public class BulkPostcodeService
{
    #region Properties
    CallManager CallManager { get; set; }
    public JObject ResponseContent { get; set; }
    public DTO<BulkPostcodeResponse> ResponseObject { get; set; }
    //the raw string of the response
    public string ResponseString { get; set; }
    public string[] PostcodesSelected { get; set; }
    #endregion

    #region Constructors
    public BulkPostcodeService(CallManager callManager)
    {
        ResponseObject = new();
        CallManager = callManager;
    }
    #endregion

    #region Methods
    public async Task MakeRequestAsync(string[] postcodes)
    {
        //registering the postcode used
        PostcodesSelected = postcodes;
        //make the request
        ResponseString = await CallManager.MakePostcodeRequestAsync(postcodes);

        ResponseContent = JObject.Parse(ResponseString);
        ResponseObject.DeserializeResponse(ResponseString);
    }

public HttpStatusCode GetResponseStatusCode() => CallManager.RestResponse.StatusCode;
    #endregion
}
