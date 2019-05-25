using UnityEngine.Events;

public class ButtonActions : ButtonSetter
{
    public UnityEvent Events;
   
    public override void Action()
    {
        if (window.Focus)
        {
           Events.Invoke();
        }
    }
}
