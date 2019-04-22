namespace Game.Controller
{
    public sealed class CheckFieldCommand : CheckEndGameCommand
    {
        public override void Execute()
        {
            if (GameModel.Cells.Count != 0)
            {
                Fail();
                if (!CheckAllFigures())
                {
                    EndGameSignal.Dispatch();
                }
            }
        }
    }
}