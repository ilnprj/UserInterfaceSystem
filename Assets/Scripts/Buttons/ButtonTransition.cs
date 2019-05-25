/// <summary>
/// Кнопка перехода
/// </summary>
public class ButtonTransition : ButtonSetter
{
    [UnityEngine.Header("id окна которое нужно вызвать:")]
    public string id;

    public override void Action()
    {
        WindowAgregator.SetWindowHandler(id);
    }
}
