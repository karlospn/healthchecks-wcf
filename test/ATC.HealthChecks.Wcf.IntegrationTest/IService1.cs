using System.ServiceModel;

namespace HealthChecks.Wcf.IntegrationTest
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData();
    }

}
