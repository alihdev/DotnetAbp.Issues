using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace DotnetAbp.Issues.Web;

[Dependency(ReplaceServices = true)]
public class IssuesBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Issues";
}
