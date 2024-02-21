# Voting and electing API/ microservices

Project consists of two microservices:
 ### Voting-API
 - REST API endpoint for returning the list of candidates
 - MassTransit endpoint\consumer for RabbitMQ message broking listening for creation of election event
 ### Electing-API
 
 - REST-API endpoint for actual voting the candidates up/down
 - MassTransit publisher when the election is created

### Applied patterns:

 - database per microservice pattern - each microservice has its own database / migrations
 - mediator pattern
 - repository pattern
 - middleware pattern

#### whole application consists of three containers - two for microservices and one for RabbitMq

There are several things which should already be done, but they aren not.
For example: base structures should have been par of Shared.csproj as they repeat in projects