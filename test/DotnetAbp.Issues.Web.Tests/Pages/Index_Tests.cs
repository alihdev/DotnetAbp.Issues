using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DotnetAbp.Issues.Pages;

public class Index_Tests : IssuesWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
