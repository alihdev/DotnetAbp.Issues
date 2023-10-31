using System.Threading.Tasks;

namespace DotnetAbp.Issues.Data;

public interface IIssuesDbSchemaMigrator
{
    Task MigrateAsync();
}
