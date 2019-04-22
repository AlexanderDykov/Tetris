using strange.extensions.command.impl;
using UnityEngine;

namespace Game.Controller
{
    public sealed class EndGameCommand : Command
    {
        public override void Execute()
        {
            Debug.Log("game over");
        }
    }
}