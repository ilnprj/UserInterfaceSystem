// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS
{
    /// <summary>
    /// Button transition to another window
    /// </summary>

    public class ButtonTransition : ButtonBaseBehaviour
    {
        [UnityEngine.Header("id окна которое нужно вызвать:")]
        public string id;
        [UnityEngine.Header("Нужно ли закрывать текущее окно по переходу:")]
        public bool needClose;

        protected override void Action()
        {
            if (window.Focus)
            {
                window.gameObject.SetActive(!needClose);
                window.Focus = false;
                WindowAgregator.SetWindowHandler(id);
            }
        }
    }
}
