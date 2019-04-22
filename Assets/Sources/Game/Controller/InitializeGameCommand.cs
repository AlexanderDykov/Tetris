using Game.Models;
using Game.Views;
using strange.extensions.command.impl;
using UnityEngine;

namespace Game.Controller
{
    public class HidebleViews
    {
        public IHideable ToHide;
        public IHideable ToSHow;
        
        public HidebleViews(IHideable hide, IHideable show)
        {
            ToHide = hide;
            ToSHow = show;
        }
    }

    public sealed class InitializeGameCommand : Command
    {
        [Inject] public HidebleViews HidebleViews{ get; set; }
        
        [Inject]
        public IGameModel GameModel{ get; set; }
        [Inject]
        public FieldView FieldView { get; set; }
        
        public override void Execute()
        {
            HidebleViews.ToHide.Hide();
            HidebleViews.ToSHow.Hide(false);
            
            if (GameModel.IsFirstLaunch)
            {
                Debug.Log("Initialize field");
                GameModel.IsFirstLaunch = false;
                FieldView.Initialize();
            }
        }
    }
}