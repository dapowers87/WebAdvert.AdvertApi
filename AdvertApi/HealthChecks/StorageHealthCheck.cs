using AdvertApi.Services;
//using Microsoft.Extensions.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdvertApi.HealthChecks
{
    public class StorageHealthCheck : IHealthCheck
    {
        private readonly IAdvertStorageService _storageService;

        public StorageHealthCheck(IAdvertStorageService storageService)
        {
            this._storageService = storageService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
             CancellationToken cancellationToken = default(CancellationToken))
        {
            var isStorageOk = await _storageService.CheckHealthAsync();
            return new HealthCheckResult(isStorageOk ? HealthStatus.Healthy : HealthStatus.Unhealthy);
        }

        //public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        //{
        //    var isStorageOk = await _storageService.CheckHealthAsync();

        //    if(isStorageOk)
        //    {
        //        return HealthCheckResult.Healthy();
        //    }
        //    else
        //    {
        //        return HealthCheckResult.Unhealthy();
        //    }
        //}
    }
}
