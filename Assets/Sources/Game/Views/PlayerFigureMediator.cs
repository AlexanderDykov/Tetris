using System.Collections.Generic;
using Game.Models;
using Game.Signals;
using Game.Utils;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Views
{
    public sealed class PlayerFigureMediator : Mediator
    {
        [Inject]
        public PlayerFigureView View { get; set; }
        
        [Inject]
        public UpdatePlayerFigureSignal UpdatePlayerFigureSignal { get; set; }
        
        [Inject]
        public DropPlayerFigureSignal DropPlayerFigureSignal { get; set; }

        [Inject]
        public IGameModel GameModel { get; set; }
        [Inject] 
        public IFigureGenerator FigureGenerator { get; set; }


        public override void OnRegister()
        {
            base.OnRegister();
            UpdatePlayerFigureSignal.AddListener(UpdateView);
            View.DropFigure.AddListener(OnDropFigure);
        }

        private List<RaycastResult> GetRaycastedObjects(PointerEventData cursor)
        {
            List<RaycastResult> objectsHit = new List<RaycastResult>();
            EventSystem.current.RaycastAll(cursor, objectsHit);
            return objectsHit;
        }

        private PointerEventData GetCursor()
        {
            var pos = View.Pool[0].transform.position;
            PointerEventData cursor = new PointerEventData(EventSystem.current)
            {
                position =
                    Camera.main.WorldToScreenPoint(
                        pos)
            };
            return cursor;
        }
        
        private void OnDropFigure()
        {
            var cursor = GetCursor();
            var objectsHit = GetRaycastedObjects(cursor);
            if (objectsHit.Count > 0)
            {
                foreach (var item in objectsHit)
                {
                    var cellComponent = item.gameObject.GetComponent<CellView>();
                    if (cellComponent != null && cellComponent.gameObject.layer == LayerMask.NameToLayer("Cell"))
                    {
                        DropPlayerFigureSignal.Dispatch(View, cellComponent.Model.Position);
                    }
                    else
                    {
                        View.SetCenterPosition();
                    }
                }
            }
            else
            {
                View.SetCenterPosition();
            }
        }

        private void UpdateView()
        {
            var randomFigure = new List<CellInfo>(FigureGenerator.GetRandomFigure());
            GameModel.Cells.Add(randomFigure);
            View.Model = randomFigure;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            UpdatePlayerFigureSignal.RemoveListener(UpdateView);
            View.DropFigure.RemoveListener(OnDropFigure);
            
        }
    }
}