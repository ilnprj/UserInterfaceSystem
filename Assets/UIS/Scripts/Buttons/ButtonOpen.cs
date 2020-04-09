using UnityEngine;

namespace UIS
{
    public class ButtonOpen : ButtonBaseBehaviour
    {
        [SerializeField]
        private WindowAsset windowAsset;

        [SerializeField]
        private bool needClose;

        protected override void Action()
        {
            if (window.Focus)
            {
                window.gameObject.SetActive(!needClose);
                window.Focus = false;
                WindowAgregator.SetWindowHandler(windowAsset.IdWindow);
            }
        }
    }
}