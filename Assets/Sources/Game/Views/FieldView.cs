using System.Collections.Generic;
using Game.Models;
using Game.Utils;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game.Views
{
    public sealed class FieldView : View
    {
        [SerializeField]
        private GameObject Cell;
        public CellView[,] Matrix;
        [Inject] public IMatrixHelper MatrixHelper { get; set; }
        [Inject] public IGameConfig GameConfig { get; set; }
        
        private int Width
        {
            get { return GameConfig.FieldWidth; }
        }
        
        private int Height
        {
            get { return GameConfig.FieldHeight; }
        }
        
        public void Initialize()
        {
            Matrix = new CellView[Width, Height];
            var startCord = MatrixHelper.GetStart(Width, Height);
            for (int x = 0; x < Width; ++x)
            {
                for (int y = 0; y < Height; ++y)
                {
                    var cell = Instantiate(Cell);
                    var cellComponent = cell.GetComponent<CellView>();
                    cellComponent.Model = new CellInfo(x, y);
                    cell.layer = LayerMask.NameToLayer("Cell");
                    cell.SetActive(true);
                    cell.transform.SetParent(transform, false);
                    ((RectTransform)cell.transform).sizeDelta = MatrixHelper.GetSizeDelta();
                    cell.transform.localPosition = MatrixHelper.GetPosition(startCord, x, y);
                    cell.name = string.Format("Cell {0}x{1}", x, y);
                    Matrix[x, y] = cellComponent;
                }
            }
        }

        public void ClearMatrix()
        {
            for (int x = 0; x < Width; ++x)
            {
                for (int y = 0; y < Height; ++y)
                {
                    Matrix[x, y].ChangeColor(CellType.Empty);
                }
            }
        }

        public bool Calculate(List<CellInfo> figure, Vector2 positionToPlace)
        {
            if (CanPlace(figure, positionToPlace))
            {
                for (int i = 0; i < figure.Count; i++)
                {
                    var cell =
                        Matrix[(int)(figure[i].Row + positionToPlace.x), (int)(figure[i].Column + positionToPlace.y)];
                    cell.ChangeColor(figure[i].CellType);
                }
                CheckMatrix();
                return true;
            }
            return false;
        }
        
        private void CheckMatrix()
        {
            List<int> rowsToRemove = new List<int>(){0,1,2,3,4,5,6,7,8,9};
            List<int> columnsToRemove = new List<int>(){0,1,2,3,4,5,6,7,8,9};

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Matrix[i, j].Model.CellType == CellType.Empty)
                    {
                        rowsToRemove.Remove(i);
                        columnsToRemove.Remove(j);
                    }
                }
            }
            RemoveRows(rowsToRemove);
            RemoveColumns(columnsToRemove);
        }

        private void RemoveRows(List<int> rowsNumber)
        {
            for (int i = 0; i < Width; i++)
            {
                if (rowsNumber.Contains(i))
                {
                    for (int j = 0; j < Height; j++)
                    {
                        //TODO: add Score
                        Matrix[i,j].ChangeColor(CellType.Empty);
                    }
                }
            }
        }
        
        
        private void RemoveColumns(List<int> columnsNumber)
        {
            for (int i = 0; i < Width; i++)
            {
                if (columnsNumber.Contains(i))
                {
                    for (int j = 0; j < Height; j++)
                    {
                        //TODO: add Score
                        Matrix[j,i].ChangeColor(CellType.Empty);
                    }
                }
            }
        }

        public bool CheckAllVariants(List<CellInfo> figure)
        {
            foreach (var item in Matrix)
            {
                if (item.Model.CellType == CellType.Empty)
                {
                    if (CanPlace(figure, item.Model.Position))
                        return true;
                }
            }
            return false;
        }
        
        public bool CanPlace(List<CellInfo> figure, Vector2 positionToPlace)
        {
            for (int i = 0; i < figure.Count; i++)
            {
                if (figure[i].Row + positionToPlace.x >= Width
                    ||(figure[i].Column + positionToPlace.y >= Height)
                    ||figure[i].Row + positionToPlace.x < 0
                    ||figure[i].Column + positionToPlace.y < 0
                    ||Matrix[(int)(figure[i].Row + positionToPlace.x), (int)(figure[i].Column + positionToPlace.y)]
                        .Model.CellType != CellType.Empty)
                {
                    return false;
                }
            }
            return true;
        }
    }
}