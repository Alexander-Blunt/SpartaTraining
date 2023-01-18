using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp.PostcodesIOService;

//Data transfer object
public class DTO<IResponse> where IResponse : new()
{
    //The class is the model of the data returned by the API call
    public IResponse Response { get; set; }

    //Method creates the above object using the response from the API
    public void DeserializeResponse(string postcodeResponse)
    {
        Response = JsonConvert.DeserializeObject<IResponse>(postcodeResponse);
    }
}
