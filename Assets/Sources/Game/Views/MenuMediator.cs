using Game.Signals;
using strange.extensions.mediation.impl;

namespace Game.Views
{
    public class MenuMediator : Mediator
    {
        [Inject]
        public MenuView View{ get; set; }

        [Inject]
        public StartGameSignal StartGameSignal { get; set; }

        public override void OnRegister() {
            base.OnRegister();
            View.StartGame.AddListener(OnStartGameClicked);
        }

        private void OnStartGameClicked()
        {
            StartGameSignal.Dispatch(View);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            View.StartGame.RemoveListener(OnStartGameClicked);
        }
    }
}