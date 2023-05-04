using System;
using Scripts.States;
using UnityEngine;

namespace Scripts
{
    public class GameCycleController
    {
        private readonly DrawLineService _drawLineService;
        private readonly MovingService _movingService;
        private readonly FailScreenService _failScreenService;
        private readonly WinScreenService _winScreenService;

        public GameCycleController(DrawLineService drawLineService, MovingService movingService, FailScreenService failScreenService,
            WinScreenService winScreenService)
        {
            _drawLineService = drawLineService;
            _movingService = movingService;
            _failScreenService = failScreenService;
            _winScreenService = winScreenService;

            SubscribeServices();

            _drawLineService.CanDraw = true;
        }

        private void SubscribeServices()
        {
            _drawLineService.OnFinishDrawingAllLines += OnFinishDrawingAllLines;
            _movingService.OnSuccessMoved += OnSuccessMoved;
            _movingService.OnFailMoved += OnFailMoved;
        }

        private void OnFailMoved()
        {
            _movingService.StopMove();
            _failScreenService.Show();
        }

        private void OnSuccessMoved()
        {
            _winScreenService.Show();
        }

        private void OnFinishDrawingAllLines()
        {
            _movingService.BeginMove();
        }
    }
}