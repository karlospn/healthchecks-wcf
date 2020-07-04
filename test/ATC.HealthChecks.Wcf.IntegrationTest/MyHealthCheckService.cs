using System.Collections.Generic;
using HealthChecks.Wcf.Enums;

namespace HealthChecks.Wcf.IntegrationTest
{
    public class MyHealthCheckService : HealthCheckBase 
    {

        protected override HealthCheckResult ExecuteHealthCheck()
        {
            return new HealthCheckResult
            {
                Message = "Everything runs smoothly",
                Status = HealthStatus.Healthy
            };
        
        }

    }
}