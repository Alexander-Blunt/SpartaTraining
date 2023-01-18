using Newtonsoft.Json.Linq;
using System.Net;

namespace APIClientApp.PostcodesIOService;

public class SinglePostcodeService
{
    #region Properties
    public CallManager CallManager { get; set; }
    public JObject ResponseContent { get; set; }
    public DTO<SinglePostcodeResponse> ResponseObject { get; set; }
    //the raw string of the response
    public string ResponseString { get; set; }
    public string PostcodeSelected { get; set; }
    #endregion

    #region Constructors
    public SinglePostcodeService(CallManager callManager)
    {
        ResponseObject = new();
        CallManager = callManager;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Defines and makes the api request, and stores the response
    /// </summary>
    /// <param name="postcode"></param>
    /// <returns></returns>
    public async Task MakeRequestAsync(string postcode)
    {
        //registering the postcode used
        PostcodeSelected = postcode;
        //make the request
        ResponseString = await CallManager.MakePostcodeRequestAsync(postcode);

        ResponseContent = JObject.Parse(ResponseString);
        ResponseObject.DeserializeResponse(ResponseString);
    }

    //Helper functions that enable ease of access to certain bits of data
    public string GetHeaderValue(string headerName)
    {
        return CallManager.RestResponse.Headers
            .Where(h => h.Name == headerName)
            .Select(h => h.Value.ToString())
            .FirstOrDefault();
    }

    public string GetResponseContentType() => CallManager.RestResponse.ContentType;
    public HttpStatusCode GetResponseStatusCode() => CallManager.RestResponse.StatusCode;
    #endregion
}
