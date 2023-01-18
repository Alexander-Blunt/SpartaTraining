using APIClientApp.PostcodesIOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientTests;

public class WhenTheBulkPostcodesServiceIsCalled_WithValidPostcodes
{
    CallManager _callManager;
    BulkPostcodeService _bulkPostcodeService;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        _callManager = new CallManager();
        _bulkPostcodeService = new BulkPostcodeService(_callManager);
        await _bulkPostcodeService.MakeRequestAsync(new string[] { "PR3 0SG", "M45 6GN", "EX165BL" });
    }

    [Test]
    public void StatusIs200()
    {
        Assert.That((int) _bulkPostcodeService.GetResponseStatusCode(), Is.EqualTo(200));
    }
}
