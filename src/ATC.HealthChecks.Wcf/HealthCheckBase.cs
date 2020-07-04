using System.Net;
using System.ServiceModel.Web;
using HealthChecks.Wcf.Enums;

namespace HealthChecks.Wcf
{
    public abstract class HealthCheckBase : IHealthCheckService
    {
        public HealthCheckResponse CheckHealth()
        {
            var result = EvaluateHealthCheck();
            return MappedResultToResponse(result);

        }

        private HealthCheckResult EvaluateHealthCheck()
        {
            var healthCheckResult = ExecuteHealthCheck();

            if (healthCheckResult == null || 
                string.IsNullOrEmpty(healthCheckResult.Message))
            {
                throw new WebFaultException<string>(
                    "Something when wrong on your healthcheck. Check your implementation", 
                    HttpStatusCode.InternalServerError);

            }
            if (healthCheckResult.Status == HealthStatus.Unhealthy)
            {
                throw new WebFaultException<HealthCheckResult>(
                    healthCheckResult, 
                    HttpStatusCode.InternalServerError);
            }

            return healthCheckResult;
        }

        private HealthCheckResponse MappedResultToResponse(HealthCheckResult result)
        {
            return new HealthCheckResponse
            {
                Status = result.Status.ToString(),
                Message = result.Message
            };
        }

        protected abstract HealthCheckResult ExecuteHealthCheck();
    }
}
