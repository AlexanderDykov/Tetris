using Game.Signals;
using strange.extensions.mediation.impl;

namespace Game.Views
{
    public class EndGameMediator : Mediator
    {
        [Inject]
        public EndGameView View { get; private set; }

        [Inject]
        public FinishGameSignal FinishGameSignal  { get; private set; }
        
        [Inject]
        public EndGameSignal EndGameSignal { get; private set; }
        
        [Inject]
        public StartGameSignal StartGameSignal { get; set; }


        public override void OnRegister()
        {
            base.OnRegister();
            EndGameSignal.AddListener(OnEndGame);
            View.StartGame.AddListener(OnGameStart);
            View.EndGameSignal.AddListener(OnEndGameClick);
        }

        private void OnGameStart()
        {
            StartGameSignal.Dispatch(View);
        }

        private void OnEndGame()
        {
            View.Hide(false);
        }

        private void OnEndGameClick()
        {
            FinishGameSignal.Dispatch();
        }

        public override void OnRemove()
        {
            base.OnRemove();
            EndGameSignal.RemoveListener(OnEndGame);
            View.StartGame.AddListener(OnGameStart);
            View.EndGameSignal.RemoveListener(OnEndGameClick);
        }
    }
}