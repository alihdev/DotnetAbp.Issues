using DotnetAbp.Issues.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DotnetAbp.Issues.Permissions;

public class IssuesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(IssuesPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(IssuesPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<IssuesResource>(name);
    }
}
