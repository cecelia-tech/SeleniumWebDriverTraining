﻿using System.Collections;
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

        var data = new List<string?>()
        {
            doc?.Element("first_name")?.Value,
            doc?.Element("last_name")?.Value,
            doc?.Element("email")?.Value,
            doc?.Element("password")?.Value,
            doc?.Element("address")?.Value,
            doc?.Element("city")?.Value,
            doc?.Element("state")?.Value,
            doc?.Element("zip_code")?.Value,
            doc?.Element("country")?.Value,
            doc?.Element("mobile_phone")?.Value,
            doc?.Element("alias")?.Value
        };

        return data;
    }

    internal static string? GetElementValue(string element)
    {
        XDocument? doc = XDocument.Load("RegisterFormData.xml");

        return doc?.Element("testdata")?.Element("address")?.Element(element)?.Value;
    }
}
