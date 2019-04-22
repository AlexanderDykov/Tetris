using Game.Signals;

namespace Game.Controller
{
    public sealed class CreateFiguresCommand : CheckEndGameCommand
    {
        [Inject]
        public UpdatePlayerFigureSignal UpdatePlayerFigureSignal { get; set; }
        
        
        public override void Execute()
        {
            UpdatePlayerFigureSignal.Dispatch();
            
            if (!CheckAllFigures())
            {
                //game over
                EndGameSignal.Dispatch();
            }
        }

    }
}