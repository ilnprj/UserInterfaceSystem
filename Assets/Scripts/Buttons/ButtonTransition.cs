/// <summary>
/// Кнопка перехода
/// </summary>

public class ButtonTransition : ButtonBaseBehaviour
{
    [UnityEngine.Header("id окна которое нужно вызвать:")]
    public string id;
    [UnityEngine.Header("Нужно ли закрывать текущее окно по переходу:")]
    public bool needClose;

    public override void Action()
    {
        if (window.Focus)
        {
            window.gameObject.SetActive(!needClose);
            window.Focus = false;
            WindowAgregator.SetWindowHandler(id);
        }
        
    }
}
