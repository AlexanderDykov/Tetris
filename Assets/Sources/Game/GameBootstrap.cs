using strange.extensions.context.impl;
using UnityEngine;

namespace Game
{
    public class GameBootstrap : ContextView
    {
        [SerializeField]
        private UIManager _uiManager;
        private GameContext _context;
        
        private void Awake()
        {
            _context = new GameContext(_uiManager, this);
            _context.Start();
            _context.Launch();
        }
    }
}