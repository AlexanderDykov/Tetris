using Game.Models;
using Game.Signals;
using Game.Views;
using strange.extensions.command.impl;

namespace Game.Controller
{
    public abstract class CheckEndGameCommand : Command
    {
        [Inject]
        public IGameModel GameModel { get; private set; }
        [Inject]
        public FieldView Field { get; private set; }
        [Inject]
        public EndGameSignal EndGameSignal { get; private set; }
        
        protected bool CheckAllFigures()
        {
            for (int i = 0; i < GameModel.Cells.Count; i++)
            {
                if (Field.CheckAllVariants(GameModel.Cells[i]))
                    return true;
            }
            return false;
        }
    }
}