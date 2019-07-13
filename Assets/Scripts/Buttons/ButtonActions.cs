using UnityEngine.Events;

public class ButtonActions : ButtonBaseBehaviour
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
