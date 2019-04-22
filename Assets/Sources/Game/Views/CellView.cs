using Game.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{    
    public sealed class CellView : ViewWithModel<CellInfo>
    {
        [SerializeField] private Image _image;
        [SerializeField] private Color _emptyCellColor;
        [SerializeField] private Color _filledCellColor;

        protected override void Awake()
        {
            base.Awake();
            if (_image == null)
                _image = GetComponent<Image>();
        }

        protected override void OnModelChanged(CellInfo model)
        {
            _image.color = model.CellType == CellType.Empty ? _emptyCellColor : _filledCellColor;
        }

        public void ChangeColor(CellType cellType)
        {
            Model.CellType = cellType;
            OnModelChanged(Model);
        }
    }
}