using APIClientApp.PostcodesIOService;

namespace APIClientTests;

public class WhenTheSinglePostcodeServiceIsCalled_WithInvalidPostcode
{
    CallManager _callManager;
    SinglePostcodeService _singlePostcodeService;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        _callManager = new CallManager();
        _singlePostcodeService = new SinglePostcodeService(_callManager);
        await _singlePostcodeService.MakeRequestAsync("Garbage");
    }

    [Test]
    public void StatusIs404()
    {
        Assert.That((int) _singlePostcodeService.GetResponseStatusCode(), Is.EqualTo(404));
    }

    [Test]
    public void ErrorIsInvalidPostcode()
    {
        Assert.That(_singlePostcodeService.ResponseContent["error"].ToString(), Is.EqualTo("Invalid postcode"));
    }
}
