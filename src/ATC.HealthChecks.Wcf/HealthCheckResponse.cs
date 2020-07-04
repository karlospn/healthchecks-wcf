using System.Runtime.Serialization;

namespace HealthChecks.Wcf
{
    [DataContract]
    public class HealthCheckResponse
    {

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Message { get; set; }

    }
}