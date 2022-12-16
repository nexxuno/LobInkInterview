# LobInkInterview
The API is working and should satisfy the requirement but...

## Testing
I only started implementing unit tests. The code has been designed to be easily testable with dependency injection and mocks.

Normally I would do this class by class and not at the end of the whole work. I would test both positive and negative paths as much as possible. I usually consider a good line coverage when it's at least at 80%.

Sometimes I also use FluentAssertions instead of the standard ones.


## Modeling
This way of modeling the data makes it very easy to handle versioning of the adventure definitions, it has the drawback of a lot of duplication (which with a NoSQL DB may be acceptable, depending on the applicaton).
Also the model now is a bit poor, I could immagine for example that the UI could need to store the url to retrieve the background image associated to an adventure definition, icons, ...
Also I would normally store Creation and LastModified dates.


## Input validation
More checks could be added on the validity of the user choices, for example that only one path is selected from root to one leaf.

## Swagger
Some return types+codes are correctly shown in swagger, this is due to the fact that I've used a new ASP.NET Core functionality and then I found out it's not so stable: https://github.com/dotnet/aspnetcore/issues/44988
This should not be a problem for our purpose, normally I would rework the code and use another solution.

## Authentication and Authorization
The webapi has no auth at the moment. The app is also mono-user. I would immagine we could receive two different roles in a JWT, some users should be able to define adventures and some others should not. Ideally the standard user should only fetch the adventures he compiled so we would also need to store the owner.

## Comments and logs
I usually comment code much more.
Moreover there are currently no logs (but the loggers are injected where they are needed).

## Dlls
Normally I would probably create one project for the data access layer, one for a services layer. The tests would be split similarly.
Also normally my controllers have possibly no BL in them and the services layer is much more fat.



# Assignement
Choose your own adventure
Create a back-end for a simple web application which allows a player to choose their own 
adventure by picking from multiple choices in order to progress to the next set of choices, 
until they get to one of the endings. You should be able to persist the player’s choices and in 
the end, show the steps they took to get to the end of the game.
The front enders need you to build endpoints for 3 pages. 
1. A “Create an Adventure” page which lets creators design the adventure. It’s ok to 
pass a full adventure tree to/from these endpoints.
2. A “Take an Adventure” page where the users can go through the adventure, make 
their choices, get to the end and persist the path they took. 
3. A “My Adventure” page that shows the result of the adventure with highlighted
choices that the user has made in their story.
This is an open-ended exercise but we would like you to use .net Core with OpenAPI 
(Swagger), Docker and have meaningful test coverage.
We really care about clean, readable code, clean application architecture and meaningful 
tests – the app should be simple, readable and covered with tests.
We are not specific about what database you use, and are happy with any data store 
approach you find most efficient for this task.
We should be able to run your application with docker and access the swagger page. 
Create a github repo for your project and send it to us when you’re ready.
In the end, just have fun
