using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APIClientApp.PostcodesIOService;

public class SinglePostcodeResponse : IResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }
    [JsonProperty("result")]
    public Postcode Postcode { get; set; }
}

public class BulkPostcodeResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }
    [JsonProperty("result")]
    public IndividualResponse[] Responses { get; set; }
}

public class IndividualResponse
{
    [JsonProperty("query")]
    public string Query { get; set; }
    [JsonProperty("result")]
    public Postcode Postcode { get; set; }
}

public class Postcode
{
    public string postcode { get; set; }
    public int quality { get; set; }
    public int eastings { get; set; }
    public int northings { get; set; }
    public string country { get; set; }
    public string nhs_ha { get; set; }
    public float longitude { get; set; }
    public float latitude { get; set; }
    public string european_electoral_region { get; set; }
    public string primary_care_trust { get; set; }
    public string region { get; set; }
    public string lsoa { get; set; }
    public string msoa { get; set; }
    public string incode { get; set; }
    public string outcode { get; set; }
    public string parliamentary_constituency { get; set; }
    public string admin_district { get; set; }
    public string parish { get; set; }
    public string admin_county { get; set; }
    public string date_of_introduction { get; set; }
    public string admin_ward { get; set; }
    public string ced { get; set; }
    public string ccg { get; set; }
    public string nuts { get; set; }
    public string pfa { get; set; }
    public Codes codes { get; set; }
}

public class Codes
{
    public string admin_district { get; set; }
    public string admin_county { get; set; }
    public string admin_ward { get; set; }
    public string parish { get; set; }
    public string parliamentary_constituency { get; set; }
    public string ccg { get; set; }
    public string ccg_id { get; set; }
    public string ced { get; set; }
    public string nuts { get; set; }
    public string lsoa { get; set; }
    public string msoa { get; set; }
    public string lau2 { get; set; }
    public string pfa { get; set; }
}
