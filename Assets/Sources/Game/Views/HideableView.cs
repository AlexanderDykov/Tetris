using strange.extensions.mediation.impl;

namespace Game.Views
{
    public class HideableView : View, IHideable
    {
        public void Hide(bool isHide = true)
        {
            gameObject.SetActive(!isHide);
        }
    }
}