using System.Collections.Generic;
using Game.Models;
using Game.Views;
using strange.extensions.command.impl;
using UnityEngine;

namespace Game.Controller
{
    public sealed class StartGameCommand : Command
    {
        [Inject] public IHideable MenuView { get; set; }
        
        [Inject] public IGameModel GameModel{ get; set; }

        [Inject] public FieldView Field { get; set; }
        
        public override void Execute()
        {
            Debug.Log("Start game");
            MenuView.Hide();
            GameModel.Cells = new List<List<CellInfo>>();
            Field.ClearMatrix();
        }
    }
}