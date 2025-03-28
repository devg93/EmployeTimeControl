

namespace TimeInTimeOut.Module.Core.TimeInTimeOutWorker.CommonServices.PersistenceService.Commands;
    public class TimeOutWriteCommandHendler : IRequestHandler<TimeOutWriCommands, bool>
    {
         private readonly IcomingAndgoingRepositoryCommand comingAndgoingRepositoryCommand;
        public TimeOutWriteCommandHendler(IcomingAndgoingRepositoryCommand icomingAndgoingRepositoryCommand)
        => this.comingAndgoingRepositoryCommand = icomingAndgoingRepositoryCommand;
        public async Task<bool> Handle(TimeOutWriCommands request, CancellationToken cancellationToken)
        {
            var timeIn = new ComingAndgoing
            {
            OfflineTime = new List<DateTime> {request.OflineTime },

            };
            return await comingAndgoingRepositoryCommand.CreateTime(timeIn);
        }
    }
