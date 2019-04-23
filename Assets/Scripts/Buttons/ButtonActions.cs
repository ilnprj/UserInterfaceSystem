using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class ButtonActions : MonoBehaviour
{
    public UnityEvent Actions;
    private Button btn;

    private void Awake() => btn.onClick.AddListener(delegate { CallAction(); });

    private void CallAction() => Actions.Invoke();

}
