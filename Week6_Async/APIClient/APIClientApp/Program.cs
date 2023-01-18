using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using APIClientApp.PostcodesIOService;

namespace APIClientApp;

public class Program
{
    public static void Main(string[] args)
    {
        var postcode = GetSinglePostcode("EC2Y5AS");
        Console.WriteLine(postcode.Postcode.admin_district);

        var postcodes = GetMultiplePostcodes(new string[] { "PR3 0SG", "M45 6GN", "EX165BL" });
        foreach (var response in postcodes.Responses)
        {
            Console.WriteLine(response.Postcode.admin_district);
        }
    }

    public static BulkPostcodeResponse GetMultiplePostcodes(string[] postcodes)
    {
        var client = new RestClient("https://api.postcodes.io/postcodes");
        var request = new RestRequest();
        request.Method = Method.Post;
        request.Timeout = -1;
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(new {Postcodes = postcodes });
        RestResponse response = client.Execute(request);
        return JsonConvert.DeserializeObject<BulkPostcodeResponse>(response.Content);
    }

    public static SinglePostcodeResponse GetSinglePostcode(string postcode)
    {
        var restClient = new RestClient("https://api.postcodes.io/");

        var restRequest = new RestRequest();

        //build the request
        restRequest.Method = Method.Get;
        restRequest.AddHeader("Content-Type", "application/json");
        restRequest.Timeout = -1;
        restRequest.Resource = $"postcodes/{postcode}";

        var singlePostcodeResponse = restClient.Execute(restRequest);

        return JsonConvert.DeserializeObject<SinglePostcodeResponse>(singlePostcodeResponse.Content);
    }
}