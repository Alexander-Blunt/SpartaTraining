using APIClientApp.PostcodesIOService;

namespace APIClientTests;

public class WhenTheSinglePostcodeServiceIsCalled_WithValidPostcode
{
    CallManager _callManager;
    SinglePostcodeService _singlePostcodeService;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        _callManager = new CallManager();
        _singlePostcodeService = new SinglePostcodeService(_callManager);
        await _singlePostcodeService.MakeRequestAsync("EC2Y 5AS");
    }
    [Test]
    public void StatusIs200_InJsonResponseBody()
    {
        Assert.That(_singlePostcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
    }
    [Test]
    public void StatusIs200()
    {
        Assert.That((int)_singlePostcodeService.GetResponseStatusCode(), Is.EqualTo(200));
    }

    [Test]
    public void StatusIs200_OnObject()
    {
        Assert.That((int)_singlePostcodeService.ResponseObject.Response.Status, Is.EqualTo(200));
    }

    [Test]
    public void CorrectPostcodeIsReturned()
    {
        Assert.That(_singlePostcodeService.ResponseContent["result"]["postcode"].ToString(), Is.EqualTo("EC2Y 5AS"));
    }

    [Test]
    public void ContentType_IsJson()
    {
        Assert.That(_singlePostcodeService.GetResponseContentType(), Is.EqualTo("application/json"));
    }

    [Test]
    public void ConnectionIsKeepAlive()
    {
        var result = _singlePostcodeService.CallManager.RestResponse.Headers.Where(x => x.Name == "Connection").Select(x => x.Value.ToString()).FirstOrDefault();

        Assert.That(result, Is.EqualTo("keep-alive"));
    }
}