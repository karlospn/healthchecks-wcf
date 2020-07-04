using HealthChecks.Wcf.Enums;

namespace HealthChecks.Wcf
{
    public class HealthCheckResult
    {

        public HealthStatus Status  {get;set;}

        public string Message { get; set; }

    }
}
