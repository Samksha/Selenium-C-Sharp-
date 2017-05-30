using System;
using System.Collections.Generic;

public class OGYamlReader
{
    public string Url { get; set; }
    public string TestData { get; set; }
    public String TestResult { get; set; }
    public String SearchKey { get; set; }
    public String Language { get; set; }
    public List<Dictionary<String, String>> PageTitles { get; set; }
}
