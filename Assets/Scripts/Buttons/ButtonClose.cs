/// <summary>
/// Кнопка которая назначается автоматически и закрывает текущее окно.
/// </summary>
public class ButtonClose : ButtonSetter
{
    private Window window;

    public override void Awake()
    {
        base.Awake();
        window = GetComponentInParent<Window>();
    }

    public override void Action()
    {
        window.OnClose();
    }
}
