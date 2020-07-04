using System.ServiceModel;
using System.ServiceModel.Web;

namespace HealthChecks.Wcf
{
    [ServiceContract(Name ="health")]
    public interface IHealthCheckService
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET", 
            UriTemplate = "/check", 
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        HealthCheckResponse CheckHealth();
    }
}