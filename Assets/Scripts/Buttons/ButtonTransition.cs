/// <summary>
/// Кнопка перехода
/// </summary>
public class ButtonTransition : ButtonSetter
{
    public string id;
    
    private void Start() => button.onClick.AddListener(delegate { Transition();});

    private void Transition() => WindowAgregator.SetWindowHandler(id);
}
