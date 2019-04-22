using System.Collections.Generic;
using Game.Models;
using Game.Utils;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Views
{
    public sealed class PlayerFigureView : ViewWithModel<List<CellInfo>>, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] 
        private GameObject _сell;
        [SerializeField]
        private Transform _center;
        [Inject] public IMatrixHelper MatrixHelper { get; set; }
        
        private Transform _movable;
        public readonly List<CellView> Pool = new List<CellView>();
        private Vector2 _centerPosition;

        public Signal DropFigure = new Signal();

        protected override void OnModelChanged(List<CellInfo> model)
        {
            HideAll();
            for (int i = 0; i < model.Count; i++)
            {
                CellView cell = null;
                if (i > Pool.Count - 1)
                {
                    cell = Instantiate(_сell).GetComponent<CellView>();
                    Pool.Add(cell);
                }
                else
                {
                    cell = Pool[i];
                }
                var x = model[i].Row;
                var y = model[i].Column;
                
                cell.Model = new CellInfo(x, y, model[i].CellType);
                cell.gameObject.SetActive(true);
                cell.transform.SetParent(transform, false);
                ((RectTransform)cell.transform).sizeDelta = MatrixHelper.GetSizeDelta();
                cell.transform.localPosition = MatrixHelper.GetPosition(Vector2.zero, x, y);
                cell.name = string.Format("Cell {0}x{1}", x, y);
            }
            
            _centerPosition = FindCenter ();
            
            _center.localPosition = MatrixHelper.GetPosition(Vector2.zero, _centerPosition.x, _centerPosition.y);
           

            for (int i = 0; i < Pool.Count; i++)
            {
                Pool[i].transform.SetParent (_center.transform);
            }

            SetCenterPosition();
        }

        public void SetCenterPosition()
        {
            _center.position = transform.position;
        }

        public Vector2 FindCenter()
        {
            int minX = int.MaxValue;
            int minY = int.MaxValue;

            int maxX = int.MinValue;
            int maxY = int.MinValue;

            foreach (var pt in Model)
            {
                // min point
                if (pt.Row < minX)
                    minX = pt.Row;
                if (pt.Column < minY)
                    minY = pt.Column;

                // max point
                if (pt.Row > maxX)
                    maxX = pt.Row;
                if (pt.Column > maxY)
                    maxY = pt.Column;
            }
            return new Vector2((float)(minX + maxX) / 2,(float) (minY + maxY) / 2);
        }

        private void Update()
        {
            if (_movable == null) return;
            
            var tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tmp.z = 0;
            _movable.position = tmp;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _movable = _center.transform;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            DropFigure.Dispatch();
            _movable = null;
        }

        public void HideAll()
        {
            for (int i = 0; i < Pool.Count; i++)
            {
                Pool[i].gameObject.SetActive(false);
            }
        }
    }
}