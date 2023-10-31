using Volo.Abp.Settings;

namespace DotnetAbp.Issues.Settings;

public class IssuesSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(IssuesSettings.MySetting1));
    }
}
