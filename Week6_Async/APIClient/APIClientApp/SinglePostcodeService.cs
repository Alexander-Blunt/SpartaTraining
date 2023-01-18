using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp;

public class SinglePostcodeService
{
    #region Properties
    //RestSharp object which handles communication with the Postcodes.io API
    public RestClient Client { get; set; }
    //capture the response
    public RestResponse Response { get; set; }
    //a Newtonsoft JObject to represent the json response
    public JObject ResponseContent { get; set; }
    public SinglePostcodeResponse ResponseObject { get; set; }
    #endregion

    public SinglePostcodeService()
    {
        Client = new RestClient(AppConfigReader.BaseUrl);
    }

    public async Task MakeRequestAsync(string postcode)
    {
        var restClient = new RestClient("https://api.postcodes.io/");

        var restRequest = new RestRequest();

        //build the request
        restRequest.Method = Method.Get;
        restRequest.AddHeader("Content-Type", "application/json");
        restRequest.Timeout = -1;
        restRequest.Resource = $"postcodes/{postcode}";

        Response = await restClient.ExecuteAsync(restRequest);
        ResponseContent = JObject.Parse(Response.Content);
        ResponseObject = JsonConvert.DeserializeObject<SinglePostcodeResponse>(Response.Content);
    }
}
