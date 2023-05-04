using System;
using Services;

namespace Scripts
{
    public class GameCycleController : IDisposable
    {
        private readonly DrawLineService _drawLineService;
        private readonly MovingService _movingService;
        private readonly FailScreenService _failScreenService;
        private readonly WinScreenService _winScreenService;

        public GameCycleController(DrawLineService drawLineService, MovingService movingService,
            FailScreenService failScreenService,
            WinScreenService winScreenService)
        {
            _drawLineService = drawLineService;
            _movingService = movingService;
            _failScreenService = failScreenService;
            _winScreenService = winScreenService;

            SubscribeServices();

            _drawLineService.CanDraw = true;
        }

        public void Dispose() =>
            UnSubscribeServices();


        private void OnFailMoved()
        {
            _movingService.StopMove();
            _failScreenService.Show();
        }

        private void OnSuccessMoved() =>
            _winScreenService.Show();

        private void OnFinishDrawingAllLines() =>
            _movingService.BeginMove();

        private void SubscribeServices()
        {
            _drawLineService.OnFinishDrawingAllLines += OnFinishDrawingAllLines;
            _movingService.OnSuccessMoved += OnSuccessMoved;
            _movingService.OnFailMoved += OnFailMoved;
        }

        private void UnSubscribeServices()
        {
            _drawLineService.OnFinishDrawingAllLines -= OnFinishDrawingAllLines;
            _movingService.OnSuccessMoved -= OnSuccessMoved;
            _movingService.OnFailMoved -= OnFailMoved;
        }
    }
}