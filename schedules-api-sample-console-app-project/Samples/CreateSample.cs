/*---------------------------------------------------------------------------------------------
* Copyright (c) Bentley Systems, Incorporated. All rights reserved.
* See LICENSE.md in the project root for license terms and full copyright notice.
*--------------------------------------------------------------------------------------------*/
using SchedulesApiSampleConsoleApp.Operations.Schedules;
using SchedulesApiSampleConsoleApp.Operations.Resources;
using SchedulesApiSampleConsoleApp.Operations.Tasks;
using SchedulesApiSampleConsoleApp.Operations.Operation;
using SchedulesApiSampleConsoleApp.Validation;

namespace SchedulesApiSampleConsoleApp.Samples
{
    internal class CreateSample
    {
        private readonly ScheduleOperations _scheduleOperations;
        private readonly ResourceOperations _resourceOperations;
        private readonly TaskOperations _taskOperations;
        private readonly OperationOperations _operationOperations;

        public CreateSample(
            ScheduleOperations scheduleOperations,
            ResourceOperations resourceOperations,
            TaskOperations taskOperations,
            OperationOperations operationOperations)
        {
            _scheduleOperations = scheduleOperations;
            _resourceOperations = resourceOperations;
            _taskOperations = taskOperations;
            _operationOperations = operationOperations;
        }

        public ISample RunSample(Arguments arguments, Configuration configuration)
        {
            if (arguments.GetSchedule)
            {
                return new GetSingleScheduleSample(_scheduleOperations, configuration);
            }

            if (arguments.GetSingle)
            {
                return new GetSingleSample(_taskOperations, configuration);
            }

            if (arguments.GetAll)
            {
                return new GetAllSample(_taskOperations, configuration);
            }

            if (arguments.Post)
            {
                var validator = new ResourceStatusPostValidator();
                return new PostSample(_resourceOperations, _operationOperations, validator, configuration);
            }

            if (arguments.Pagination)
            {
                return new PaginationSample(_taskOperations, configuration);
            }

            return new DefaultSample(_resourceOperations, _taskOperations, _operationOperations, configuration);
        }
    }
}
