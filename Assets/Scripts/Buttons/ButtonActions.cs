using UnityEngine.Events;

public class ButtonActions : ButtonSetter
{
    public UnityEvent Actions;
    
    private void Start() => button.onClick.AddListener(delegate { CallAction(); });

    private void CallAction() => Actions.Invoke();
}
