using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public class MenuView : HideableView
    {
        [SerializeField] private Button _startGameBtn;
        public Signal StartGame = new Signal();

        protected override void Start()
        {
            base.Start();
            _startGameBtn.onClick.AddListener(StartGameClick);
        }
        

        private void StartGameClick()
        {
            StartGame.Dispatch();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _startGameBtn.onClick.RemoveListener(StartGameClick);
        }
    }
}