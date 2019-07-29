using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Countries
/// </summary>
public class Countries
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Capital { get; set; }
    public string PhoneCode { get; set; }
    public string ContinentCode { get; set; }
    public string CurrencyISOCode { get; set; }
    public string Languages { get; set; }
   
    
    public Countries(string aname, string aCode, string aCapital, string aPhoneCode, 
        string aContinentCode, string aCurrencyISOCode, string aLanguages)
    {
        Name = aname;
        Code = aCode;
        Capital = aCapital;
        PhoneCode = aPhoneCode;
        ContinentCode = aContinentCode;
        CurrencyISOCode = aCurrencyISOCode;
        Languages = aLanguages;
    }
    
}