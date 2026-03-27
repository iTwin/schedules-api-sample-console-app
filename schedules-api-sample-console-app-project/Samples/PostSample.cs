/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Models.Resources;
using SchedulesApiSampleConsoleApp.Operations.Operation;
using SchedulesApiSampleConsoleApp.Operations.Resources;
using SchedulesApiSampleConsoleApp.Validation;

namespace SchedulesApiSampleConsoleApp.Samples
{
	internal class PostSample : ISample
	{
		private readonly ResourceOperations _resourceOperations;
		private readonly OperationOperations _operationOperations;
		private readonly ResourceStatusPostValidator _validator;
		public string _requestUri { get; }

		public PostSample(ResourceOperations resourceOperations, OperationOperations operationOperations, ResourceStatusPostValidator validator, Configuration configuration)
		{
			_resourceOperations = resourceOperations;
			_operationOperations = operationOperations;
			_validator = validator;
			_requestUri = configuration.ServiceHost.ToString();
		}

		public async Task ExecuteAsync(string scheduleId)
		{
			Console.WriteLine("=".PadRight(80, '='));
			Console.WriteLine("SAMPLE: Post Resource Status History");
			Console.WriteLine("=".PadRight(80, '='));
			Console.WriteLine();

			Console.WriteLine("This Sample shows how POSTs work. A Resource Status History Item will be created.");
			Console.WriteLine();

			Console.WriteLine("[ STEP 1: Getting a Resource ID for the Post Request ]");
			Console.WriteLine("First a Resource ID must be found. This will be done by Getting all Resource Entities and picking one.");
			Console.WriteLine($"Sending GET request to {_requestUri}schedules/{scheduleId}/resources\n");
			var allResources = await _resourceOperations.FetchResourceAsync(scheduleId);
			Console.WriteLine();

			if (allResources?.Resources?.Count > 0)
			{
				var firstResourceId = allResources.Resources[0].Id;
				Console.WriteLine("The first Resource on the list will be used for the POST request.");
				Console.WriteLine("For demonstration purposes the single resource will be requested to seperate it out.");
				Console.WriteLine($"Sending GET request to {_requestUri}schedules/{scheduleId}/resources/{firstResourceId}\n");
				await _resourceOperations.FetchSingleResourceItemAsync(scheduleId, firstResourceId);
				Console.WriteLine();

				Console.WriteLine("[ Optional: Checking current Resource Status Histories ]");
				Console.WriteLine("Now that the Resource ID has been chosen, the ResourceStatusHistory endpoint can be queried to check all Status Histories matching that ID.");
				Console.WriteLine("This shows that the Resource Status History that is to be created does not exist yet.");
				Console.WriteLine($"Sending GET request to {_requestUri}schedules/{scheduleId}/resources/{firstResourceId}/status-history\n");
				await _resourceOperations.FetchResourceStatusHistoryAsync(scheduleId, firstResourceId);
				Console.WriteLine();

				var allStatusItems = await _resourceOperations.FetchResourceStatusItemsAsync(scheduleId);
				if (allStatusItems?.ResourceStatusItems?.Count > 0)
				{
					var firstStatusItemId = allStatusItems.ResourceStatusItems[0].Id;
					var postResourceStatusItemData = new ResourceStatusPostItem
					{
						ResourceId = firstResourceId,
						Date = DateTime.Now,
                        StatusItemId = firstStatusItemId,
					};

					Console.WriteLine("[ STEP 2: Ensure all required values have data ]");
					Console.WriteLine("Now that the Resource ID has been chosen, A StatusItemId can be found similar to 'Step 1' to be used in the POST.");
					Console.WriteLine("For this example the status item used will be:");
					Console.WriteLine($"StatusItemId: '{firstStatusItemId}'\n");

					var validationResult = _validator.Validate(postResourceStatusItemData, firstResourceId, firstStatusItemId);

					if (!validationResult.IsValid)
					{
						Console.WriteLine($"Validation for Post request values failed: {validationResult.ErrorMessage}\n");
						return;
					}

					Console.WriteLine("[ STEP 3: Send POST Request ]");
					Console.WriteLine("A POST ResourceStatusHistory will now be sent using the provided IDs to the following URL.\n");
					Console.WriteLine($"Sending POST request to {_requestUri}schedules/{scheduleId}/resources/status-history\n");
					var postResult = await _resourceOperations.PostResourceStatusHistoryAsync(scheduleId, postResourceStatusItemData);

					if (postResult != null)
					{
						var resourceStatusHistoryId = postResult.StatusHistoryItem.Id;
						var operationId = postResult.Operation.Id;
						Console.WriteLine("[ STEP 4: Monitor Operation Status ]");
						Console.WriteLine("The Post Request was accepted, the status of the request can be viewed using the Operation Endpoint.");
						Console.WriteLine("The OperationID value found in the response will be used.");
						Console.WriteLine("Once the Operation has succeeded the Resource Status History entity will be created.\n");

						Console.WriteLine($"Sending GET request to {_requestUri}schedules/{scheduleId}/operations/{operationId}\n");
						var operationResult = await WaitForOperationCompletionAsync(scheduleId, operationId);

						if (operationResult?.Operation?.Status == "Succeeded")
						{
							Console.WriteLine("The Operation succeeded\n");

							Console.WriteLine("[ STEP 5: Verify Created Resource Status History ]");
							Console.WriteLine("Now that the operation has succeeded, the newly created Resource Status History can be searched.");
							Console.WriteLine("This is done using the ID value returned in the response for the POST request to the following URL.\n");
							Console.WriteLine($"Sending GET request to {_requestUri}schedules/{scheduleId}/resources/status-history/{resourceStatusHistoryId}\n");
							await _resourceOperations.FetchSingleResourceStatusHistoryItemAsync(scheduleId, resourceStatusHistoryId);
						}
					}
					else
					{
						Console.WriteLine("The was an error with the POST request.");
					}
				}

                else
				{
					Console.WriteLine("There were no items found for the Resource Status GET request.\n");
                    Console.WriteLine("A resource status is required for the ResourceStatusHistory endpoint.\n");
                }
			}
			else
			{
				Console.WriteLine("There were no items found for the Resource GET request.\n");
                Console.WriteLine("A resource is required for the ResourceStatusHistory endpoint.\n");
            }
		}

		private async Task<dynamic?> WaitForOperationCompletionAsync(string scheduleId, string operationId, int maxGetAttempts = 30, int delayMilliseconds = 2000)
		{
			for (int getAttempt = 1; getAttempt <= maxGetAttempts; getAttempt++)
			{
				var result = await _operationOperations.FetchSingleOperationItemAsync(scheduleId, operationId);
				var status = result?.Operation?.Status;

				Console.WriteLine($"Operation status: {status} (attempt {getAttempt}/{maxGetAttempts})\n");

				if (status == "Succeeded" || status == "Failed")
					return result;

				if (getAttempt < maxGetAttempts)
					await Task.Delay(delayMilliseconds);
			}

			Console.WriteLine("The operation has taken to many attempts, The sample will now end.");
			return null;
		}
	}
}
