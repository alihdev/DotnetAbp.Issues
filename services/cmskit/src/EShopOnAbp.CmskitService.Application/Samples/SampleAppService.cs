using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.PermissionManagement;

namespace EShopOnAbp.CmskitService.Samples;

public class SampleAppService : CmskitServiceAppService, ISampleAppService
{
    private readonly IPermissionDefinitionRecordRepository _permissionDefinitionRecordRepository;
    private readonly IPermissionManager _permissionManager;
    private readonly IDynamicPermissionDefinitionStoreInMemoryCache _storeCache;

    public SampleAppService(IPermissionManager permissionManager, IDynamicPermissionDefinitionStoreInMemoryCache storeCache, IPermissionDefinitionRecordRepository permissionDefinitionRecordRepository)
    {
        _permissionManager = permissionManager;
        _storeCache = storeCache;
        _permissionDefinitionRecordRepository = permissionDefinitionRecordRepository;
    }

    public Task<SampleDto> GetAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }

    [Authorize]
    public Task<SampleDto> GetAuthorizedAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }

    public async Task CreatePermission(PermissionCreateDto permissionCreateDto)
    {
        // create permission record
        var permissionDefinitionRecord = new PermissionDefinitionRecord(
            Guid.NewGuid(),
            "CmskitService",
            permissionCreateDto.Name,
            permissionCreateDto.ParentName,
            permissionCreateDto.DisplayName
        );

        await _permissionDefinitionRecordRepository.InsertAsync(permissionDefinitionRecord, true);

        // clear cache
        _storeCache.LastCheckTime = null;
        _storeCache.CacheStamp = null;

        // assing admin to permission
        await _permissionManager.SetAsync(permissionCreateDto.Name, RolePermissionValueProvider.ProviderName, "admin", true);
    }
}
