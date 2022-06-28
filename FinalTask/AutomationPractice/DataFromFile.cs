using System.Collections;
using System.Xml.Linq;

namespace AutomationPractice;

internal class DataFromFile
{
    internal static IEnumerable RegisterFormData
    {
        get { return GetRegisterFormData(); }
    }

    private static IEnumerable GetRegisterFormData()
    {
        var doc = XDocument.Load("RegisterFormData.xml")?.Element("testdata")?.Element("address");

        yield return doc?.Element("first_name")?.Value;
        yield return doc?.Element("last_name")?.Value;
        yield return doc?.Element("email")?.Value;
        yield return doc?.Element("password")?.Value;
        yield return doc?.Element("address")?.Value;
        yield return doc?.Element("city")?.Value;
        yield return doc?.Element("state")?.Value;
        yield return doc?.Element("zip_code")?.Value;
        yield return doc?.Element("country")?.Value;
        yield return doc?.Element("mobile_phone")?.Value;
        yield return doc?.Element("alias")?.Value;
    }

    internal static string? GetElementValue(string element)
    {
        XDocument? doc = XDocument.Load("RegisterFormData.xml");

        return doc?.Element("testdata")?.Element("address")?.Element(element)?.Value;
    }
}
