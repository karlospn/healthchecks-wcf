# healthchecks-wcf

## Introduction

The repository contains a library that allows to add a healthcheck REST endpoint in your existing WCF (Windows Communication Foundation).   

- The library contains a dependency with Autofac, because it assumes that you're using it as a dependency injector, if you want you can change it and register the dependencies 
which whatever IoC you are using.

---

## How to use it

- Install the library as a nuget or as a reference.   
- Create a class that inherits from _"HealthCheckBase"_ and implement the function **ExecuteHealthCheck()**   
  - The returned value from the method **ExecuteHealthCheck** is going to be the healthcheck endpoint output.   
- In the web.config file add the following block:   
```xml
<serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true" >
  <serviceActivations>
    <add relativeAddress="health.svc" 
    service="HealthChecks.Wcf.IntegrationTest.MyHealthCheckService, HealthChecks.Wcf.IntegrationTest" 
    factory="Autofac.Integration.Wcf.AutofacServiceHostFactory, Autofac.Integration.Wcf"/>
  </serviceActivations>
</serviceHostingEnvironment>
```
  - The service atribute must point to the csharp class you created thats inherits from _"HealthCheckBase"_
  - Thats the way that autofac uses to create a svc-less service:
    - https://autofaccn.readthedocs.io/en/latest/integration/wcf.html#svc-less-services
    - If you are using another IoC check the documentation.
  
