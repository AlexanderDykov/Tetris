using strange.extensions.mediation.impl;

namespace Game.Views
{
    public abstract class ViewWithModel<T> : View where T : class
    {
        private T _model;
        
        public T Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (_model == null || _model != value)
                {
                    _model = value;
                    OnModelChanged(_model);
                }
            }
        }

        protected abstract void OnModelChanged(T model);

        public void SetModelChanged()
        {
            OnModelChanged(_model);
        }
    }
}