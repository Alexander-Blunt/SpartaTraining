using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp.PostcodesIOService;

//Class to handle communication with the API
public class CallManager
{
    private readonly RestClient _client;
    public RestResponse RestResponse { get; set; }

    public CallManager()
    {
        _client = new RestClient(AppConfigReader.BaseUrl);
    }

    /// <summary>
    /// defines and makes and API request, stores the response and returns the response content.
    /// </summary>
    /// <param name="postcode"></param>
    
    public async Task<string> MakePostcodeRequestAsync(string postcode)
    {
        //build the request
        var request = new RestRequest();
        request.Method = Method.Get;
        request.AddHeader("Content-Type", "application/json");
        request.Timeout = -1;
        request.Resource = $"postcodes/{postcode.Replace(" ", "")}";

        RestResponse = await _client.ExecuteAsync(request);

        return RestResponse.Content;
    }
}
