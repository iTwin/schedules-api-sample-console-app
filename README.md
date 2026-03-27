
# Schedules Api Sample Console App

Copyright © Bentley Systems, Incorporated. All rights reserved.

This is a code sample application that demonstrates usage of Schedules API. 
It Demonstrates various example workflows that may be used within the Schedules API, including the Retrieval and Posting of data to various endpoints.
The application can be run through Visual Studio, or through the command line.

## Prerequisites

* [Git](https://git-scm.com/)
* (For non-web applications) [.NET 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
* (For web applications) [NodeJS and NPM](https://nodejs.org/en/download)
* Optionally an IDE like Visual Studio 2026 or [Visual Studio Code](https://code.visualstudio.com/). It is also possible to use command line.

## Setup

### API Client registration steps

 1. An application will need to be made, this can be done at [My Apps](https://developer.bentley.com/my-apps/) by clicking "Register New".
 2. Fill in application name. This is a display name, client id will be generated automatically.
 3. Click on "Web app" for the Application type, this will be used for gaining a token when the sample is run.
 4. Make sure `itwin-platform` scope is added under *Allowed scopes*
 5. Set the Redirect URIs to "http://localhost:5000/"
 6. Click `Register`
 7. Make sure to copy client secret and close the dialog.
 9. You should be able to authenticate now by using client id and secret with the appropriate flow.
 
### Visual Studio

1. Clone this repository.
2. Make sure you have registered an application using the API Client Registration Step.
3. To successfully run this tool you will need to have an accessible Schedule. If you do not have one a sample file `Sample-Schedule.sp` can be found on the root of this repository, this can be uploaded using the following tutorials:
[Creating a Project](https://learning.bentley.com/learn/courses/827/synchro-control-admin-training/lessons/6382/creating-a-project)
[Create a iModel using .sp file](https://learning.bentley.com/learn/courses/827/synchro-control-admin-training/lessons/6391/create-a-imodel-using-sp-file)
4. Set valid schedule ID in command line argument --schedule in Properties/launchSettings.json - this is equivalent to the project ID for the initial release.
5. Set a valid operation value in Properties/launchSettings.json. The following are available:
- `--getall` - Demonstrates the retrieval of all "Tasks" from the Tasks endpoint.
- `--getsingle` - Demonstrates the retrieval of a single "Task" from the Tasks endpoint.
- `--getschedule` - Demonstrates the retrieval of a single "Schedule" from the Schedule endpoint.
- `--pagination` - Demonstrates the retrieval of "Tasks" from the Task endpoint using the pagination tokens.
- `--post` - Demonstrates the creation of a new "Resource Status History" item using the Resource Status History endpoint.
The default behaviour (i.e. none of these options set) is to demonstrate an example workflow using the Schedules Service - the program will fetch all Resource items from a list. Afterwards, it will send a POST request to the Resource Status History endpoint using one of the Resource Ids. An operation is then created and once this succeeds the newly created Resource History Item will be retrieved.
6. Set a valid ClientId and ClientSecret in appsettings.json - these ids were created when making the the Web Application using [My Apps](https://developer.bentley.com/my-apps/)
7. run in debug mode.

### Command Line
1. Clone Repository
2. Change directory into cloned folder `cd EsApi4DScheduleSampleApp`
3. Build app with `dotnet build`
4. Change directory into build folder `cd EsApi4DScheduleSampleApp/bin/Debug/net10.0/`
5. You can configure OAuth settings in two ways:
		
	Option A: Update appsettings.json (Recommended)
		
	Edit `appsettings.json` and update the OAuth credentials:

			```json
			{
				 "ServiceHost": "https://api.bentley.com/",
				 "OAuth": {
				   "ClientId": "your-client-id",
				   "ClientSecret": "your-client-secret",
				   "RedirectUri": "http://localhost:5000/",
				   "TokenEndpoint": "https://ims.bentley.com/connect/token",
				   "AuthorizeEndpoint": "https://ims.bentley.com/connect/authorize",
				   "Scope": "itwin-platform"
				 }
			}
			```
			
	Option B: Use Command Line Arguments

	Override OAuth settings at runtime:

		```bash
		dotnet SynchroSampleApp.dll --schedule "{your_schedule_id}" --clientid "your-client-id" --clientsecret "your-client-secret" 
		```
7. Optional operations can be added to the run command from the following. A default sample will run if none are added:
- `--getall` - Demonstrates the retrieval of all "Tasks" from the Tasks endpoint.
- `--getsingle` - Demonstrates the retrieval of a single "Task" from the Tasks endpoint.
- `--getschedule` - Demonstrates the retrieval of a single "Schedule" from the Schedule endpoint.
- `--pagination` - Demonstrates the retrieval of "Tasks" from the Task endpoint using the pagination tokens.
- `--post` - Demonstrates the creation of a new "Resource Status History" item using the Resource Status History endpoint.


### Code Overview

We encourage user to understand how OAuth2 authorization workflow is implemented. In this code sample, this can be found in `src/Authentication/OAuthAuthenticator`.

`src/samples` is where most of the application logic is written. Component namings are self-explanatory, each step in the samples are clearly described to what they are doing.

### Project Structure

The full folder structure of this app is explained below:

| Name                      | Description                                                                             |
| ------------------------- | --------------------------------------------------------------------------------------- |
| **.github**               | Contains Github related files                                                           |
| **Program.cs**            | Main entry point for the console application                                            |
| **ConsoleApp.cs**         | Main entry point for the console application                                            |
| **ScheduleServiceApp.cs** | Schedule service application logic                                                      |
| **Sample-Schedule.sp**    | A sample Synchro Project file for the sample app to query                               |
| **Program.cs**            | Main entry point for the console application                                            |
| **Arguments.cs**          | Command-line argument definition                                                        |
| **appsettings.json**      | Application configuration file (OAuth, API endpoints, etc.)                             |
| **Configuration.cs**      |  Application configuration settings                                                     |
| **src**                   | Contains source code that will be compiled to the dist dir                              |
| **src/Authentication**    | Contains authentication-related components for OAuth integration                        |
| **src/Models**            | Contains data models for API requests and responses                                     |
| **src/Samples**           | Contains different sample implementations demonstrating API usage                       |
| **src/Validation**        | Contains Validation Logic                                                               |