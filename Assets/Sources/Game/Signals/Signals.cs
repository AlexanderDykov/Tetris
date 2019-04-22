using Game.Controller;
using Game.Views;
using strange.extensions.signal.impl;
using UnityEngine;

namespace Game.Signals
{
    public class InitialiseSignal : Signal<HidebleViews>{}
    public class StartGameSignal : Signal<IHideable>{}
    public class UpdatePlayerFigureSignal : Signal{}
    public class DropPlayerFigureSignal : Signal<PlayerFigureView, Vector2>{}
    public class EndGameSignal : Signal{}
    public class FinishGameSignal : Signal {}
}