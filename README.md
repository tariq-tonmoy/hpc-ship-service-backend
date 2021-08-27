# Introduction 
This is the Ship Management Service

# Sample Payload
Sample payload can be found in the following link as Postman collection:
https://www.getpostman.com/collections/c93a462e3b60b2011632

# User Authentication
The APIs use basic authentication. They are also protected using roles.
Ship creation, update and deletion can be done by user with role "Admin"
To get ship information can be done by users with roles: "Admin", "User"

# Credentials:
* Admin Roles:
    * Username: test_admin1@yopmail.com or test_admin2@yopmail.com
    * Password: Abc123
* User Role:
    * Username: test_user1@yopmail.com or test_user2@yopmail.com
    * Password: Abc123
* Anonymous Role:
    * Username: test_anon1@yopmail.com or test_anon2@yopmail.com
    * Password: Abc123

# Run Project:
* *Docker*: Run docker-compose.yml file
* *Visual Studio*: Run ShipService.sln file

# Test SignalR Client:
Each command has a *CorrelationId*. To test a response via web socket, input the correlationId in console to view json output. For better understanding of the client, you can keep the correlation Id same throughout the client test. The clinet can be run using *TestSignalRHub.sln* on Visual Studio.



