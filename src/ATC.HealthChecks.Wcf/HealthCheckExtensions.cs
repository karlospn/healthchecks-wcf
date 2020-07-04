using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace HealthChecks.Wcf
{
    public static class HealthCheckExtensions
    {
        public static Action<ServiceHostBase> AddHealthCheckEndpoint()
        {
            return serviceHost =>
            {
                serviceHost.Opening += (snd, args) =>
                     {
                         GenerateHealthEndpoint(serviceHost);
                     };
            };
        }

        private static void GenerateHealthEndpoint(ServiceHostBase serviceHost)
        {
            var implementedContracts = serviceHost
                .GetType()
                .GetProperty("ImplementedContracts", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);

            if (implementedContracts != null)
            {
                var contractDic = (Dictionary<string, ContractDescription>)implementedContracts.GetValue(serviceHost, null);
                foreach (var contract in contractDic.Values)
                {
                    if (serviceHost.Description.Endpoints.Any())
                    {
                        continue;
                    }

                    if (contract.ConfigurationName == typeof(IHealthCheckService).FullName)
                    {
                        var serviceEndpoint = new ServiceEndpoint(contract, 
                            new WebHttpBinding(), 
                            new EndpointAddress(serviceHost.BaseAddresses[0]));

                        serviceEndpoint.Behaviors.Add(new WebHttpBehavior());
                        serviceHost.AddServiceEndpoint(serviceEndpoint);
                    }
                }
            }

        }
    }
}