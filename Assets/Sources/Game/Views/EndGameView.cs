using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public sealed class EndGameView : MenuView
    {
        [SerializeField] private Button _endGame;
        public Signal EndGameSignal = new Signal();
        
        protected override void Start()
        {
            base.Start();
            _endGame.onClick.AddListener(EndGameClick);
        }

        private void EndGameClick()
        {
            EndGameSignal.Dispatch();
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            _endGame.onClick.RemoveListener(EndGameClick);
        }
    }
}