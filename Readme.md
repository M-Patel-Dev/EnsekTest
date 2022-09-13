# README #

###  Notes:### 

API Considerations
Given more time was spent on the project and to make the API production ready, the following would be done.

* The API will need to have authentication implemented to ensure it is secure, the absolute miniumum would be with the usage of an API Key.
A better approach would be to authenticate against an auth token such as JWT.

* Currently the API processes the meter readings synchronously, the service could be refactored to work async to improve speed - an example being to make use of the Entity Framework async calls. 
 
* Add further unit tests to improve code coverage as well as update the current unit tests as they have not addressed all required areas. 

* A unified logging middleware would be added to capture request and response information for auditing and error tracking purposes, this in turn would mean the error handling will be increased and updated from the current basic implementations.

* An Integration test project would be added to the solution to allow integration testing against the various components of the API including data store.

* A Front end web application would be created to consume the service this would be done via a react application.

* Selenium tests would be added to the front end application to ensure the application works as intended from a visual point of view.



The below points should be considered before deploying the API

* API credentials and secrets would be accessed via a secrets vault such as Azure Key vault instead of being stored in the appsettings.json file or Azure Devops Library assuming the repo is hosted on ADO,
The authentication would be done via a service principal or equivalent.

* Ensure the database tables are indexed to enable faster querying of the data sources. This can be done by adding an index on those fields that are used in queries such as a customer's first or last name.

* Caching could be implemented to increase site performance and reduce the amount of calls to the data sources - bearing in mind that not all data can be cached such as sensitive customer data (assuming we will be storing/accessing customer data in the api). 
  this can be implemented via a remote cache such as Redis.

* Configure/Create processes for CI/CD pipelines to allow continuous deployment of the project, Microsoft Azure Devops is once such tool that can aid in this endeavour.

* Ensure the API meets the OWASP guidelines - this will help in making the application secure and will allow the application to deal with common web application pitfalls,
  several areas of configuration and code can be added and adjusted to enable a more secure application.
  An example being Cross-Site Scripting this can be done by checking only valid input is included as part of the request, an example of this is the data annotations that can be added to a request object 
  and validated before the controller processes the request

* Penetration testing would need to be done to identify any holes in the API.

* Performance testing would need to be carried out to ensure that each API call is as efficient as possible and to identify any bottlenecks such as high cost database queries. 
Apache JMeter can be used to help with penetration and performance testing, a suite of tests can be created and ran before the 'go-live' date for the API

* The service could be deployed as a docker container and deployed via Azure or AWS instead of having to host the service on a virtual machine