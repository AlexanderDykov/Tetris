using Game.Models;
using Game.Views;
using strange.extensions.command.impl;
using UnityEngine;

namespace Game.Controller
{
    public sealed class DropFigureCommand : Command
    {
        [Inject] public PlayerFigureView FigureView { get; private set; }

        [Inject] public Vector2 Position { get; private set; }

        [Inject] public FieldView Field { get; private set; }

        [Inject] public IGameModel GameModel { get; private set; }

        public override void Execute()
        {
            if (Field.Calculate(FigureView.Model, Position))
            {
                FigureView.HideAll();
                GameModel.Cells.Remove(FigureView.Model);
            }
            else
            {
                FigureView.SetCenterPosition();
                Fail();
            }
        }
    }
}