using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Caching;
using Volo.Abp.PermissionManagement;

namespace EShopOnAbp.CmskitService.Samples;

public class SampleAppService : CmskitServiceAppService, ISampleAppService
{
    private readonly IPermissionDefinitionRecordRepository _permissionDefinitionRecordRepository;
    private readonly IPermissionManager _permissionManager;
    private readonly IDynamicPermissionDefinitionStoreInMemoryCache _storeCache;
    private readonly IDistributedCache _distributedCache;
    private AbpDistributedCacheOptions CacheOptions { get; }


    public SampleAppService(
        IPermissionManager permissionManager, 
        IDynamicPermissionDefinitionStoreInMemoryCache storeCache, 
        IPermissionDefinitionRecordRepository permissionDefinitionRecordRepository, 
        IDistributedCache distributedCache,
        IOptions<AbpDistributedCacheOptions> cacheOptions
    )
    {
        _permissionManager = permissionManager;
        _storeCache = storeCache;
        _permissionDefinitionRecordRepository = permissionDefinitionRecordRepository;
        _distributedCache = distributedCache;
        CacheOptions = cacheOptions.Value;
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
        await _distributedCache.RemoveAsync($"{CacheOptions.KeyPrefix}_AbpInMemoryPermissionCacheStamp");

        // assing admin to permission
        await _permissionManager.SetAsync(permissionCreateDto.Name, RolePermissionValueProvider.ProviderName, "admin", true);
    }
}
