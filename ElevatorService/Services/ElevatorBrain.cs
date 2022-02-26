﻿using ElevatorSim;

namespace ElevatorServer.Services
{
    public class ElevatorBrain : IElevatorBrain
    {
        private readonly IElevatorComService _comService;
        private ILogger<ElevatorBrain> _logger;

        public ElevatorBrain(IElevatorComService comService, ILogger<ElevatorBrain> logger)
        {
            _comService = comService;
            _logger = logger;
        }

        public async Task AddFromFloorRequest(FromFloorRequest request)
        {
            var elevators = await _comService.GetAllElevatorState();

            var selectedElevator = elevators.OrderBy(e => e.Commands.Count()).FirstOrDefault();

            if (selectedElevator != null)
            {
                await _comService.IssueCommand(
                    new ElevatorCommand()
                    {
                        Floor = request.FloorNumber,
                        ElevatorId = selectedElevator.ElevatorId
                    });
            }

        }

        public async Task AddToFloorRequest(ToFloorRequest request)
        {
            await _comService.IssueCommand(
                new ElevatorCommand()
                {
                    Floor = request.FloorNumber,
                    ElevatorId = request.ElevatorId
                });
        }
    }
}
