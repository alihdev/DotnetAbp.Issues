using DotnetAbp.Issues.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Globalization;

namespace DotnetAbp.Issues.Issues;

public class LocalizationIssueAppService : IssuesAppService
{
    public LocalizationIssueDto CreateAsync([FromForm] LocalizationIssueDto input)
    {
        return input;
    }

    public void TestArCulture()
    {
        var typeDescriptor = TypeDescriptor.GetConverter(typeof(decimal));

        var enCultureInfo = new CultureInfo("en");

        var resultEn1 = typeDescriptor.ConvertFrom(null, enCultureInfo, "-1"); // -1
        var resultEn2 = typeDescriptor.ConvertFrom(null, enCultureInfo, "1.25"); // 1.25

        var arCultureInfo = new CultureInfo("ar");

        try
        {
            var resultAr = typeDescriptor.ConvertFrom(null, arCultureInfo, "-1"); // System.ArgumentException: '-1 is not a valid value for Decimal. Arg_ParamName_Name'
        }
        catch (Exception ex)
        {
        }

        try
        {
            var resultAr = typeDescriptor.ConvertFrom(null, arCultureInfo, "1-"); // System.ArgumentException: '1- is not a valid value for Decimal. Arg_ParamName_Name'
        }
        catch (Exception ex)
        {
        }

        try
        {
            var resultAr = typeDescriptor.ConvertFrom(null, arCultureInfo, "1.25"); // System.ArgumentException: '1.25 is not a valid value for Decimal. Arg_ParamName_Name'
        }
        catch (Exception ex)
        {
        }
    }
}
