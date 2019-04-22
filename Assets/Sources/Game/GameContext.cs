using System;
using Game.Controller;
using Game.Models;
using Game.Signals;
using Game.Utils;
using Game.Views;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;

namespace Game
{
	public class GameContext : MVCSContext
	{
		private UIManager _uiManager;
		
		public GameContext( UIManager uiManager, GameBootstrap contextView) 
			: base (contextView, ContextStartupFlags.MANUAL_MAPPING | ContextStartupFlags.MANUAL_LAUNCH)
		{
			_uiManager = uiManager;
		}

		protected override void mapBindings()
		{
			base.mapBindings();
			InjectionsBinding();
			CommandsBinding();
			ViewsBinding();
		}

		public override void Launch()
		{
			base.Launch();
			var initSignal = injectionBinder.GetInstance<InitialiseSignal>();
			initSignal.Dispatch(new HidebleViews(_uiManager.EndGameView, _uiManager.MenuView));
		}

		private void InjectionsBinding()
		{
			injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton();
			injectionBinder.Bind<IGameConfig>().To<GameConfig>().ToSingleton();
			injectionBinder.Bind<IFigureGenerator>().To<FigureGenerator>().ToSingleton();
			injectionBinder.Bind<IMatrixHelper>().To<MatrixHelper>().ToSingleton();
			injectionBinder.Bind<UpdatePlayerFigureSignal>().To<UpdatePlayerFigureSignal>().ToSingleton();
			injectionBinder.Bind<FinishGameSignal>().To<FinishGameSignal>();
		}

		private void CommandsBinding()
		{
			commandBinder.Bind<InitialiseSignal>()
				.To<InitializeGameCommand>().Once();
			
			
			commandBinder.Bind<StartGameSignal>()
				.To<StartGameCommand>()
				.To<CreateFiguresCommand>()
				.InSequence();

			commandBinder.Bind<DropPlayerFigureSignal>()
				.To<DropFigureCommand>()
				.To<CheckFieldCommand>()
				.To<CreateFiguresCommand>()
				.InSequence();
			
			commandBinder.Bind<EndGameSignal>()
				.To<EndGameCommand>();
		}

		private void ViewsBinding()
		{
			if(injectionBinder == null || _uiManager == null)
				throw new Exception();
			
			mediationBinder.Bind<MenuView>().To<MenuMediator>();
			mediationBinder.Bind<PlayerFigureView>().To<PlayerFigureMediator>();
			injectionBinder.Bind<FieldView>().ToValue(_uiManager.Field);
			mediationBinder.Bind<EndGameView>().To<EndGameMediator>();
		}

		protected override void addCoreComponents()
		{
			base.addCoreComponents();
			injectionBinder.Unbind<ICommandBinder>();
			injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
		}

	}
}