using DotnetAbp.Issues.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAbp.Issues.Issues;

public class LocalizationIssueAppService : IssuesAppService
{
    public LocalizationIssueDto CreateAsync([FromForm] LocalizationIssueDto input)
    {
        return input;
    }
}
