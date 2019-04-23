using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Кнопка перехода
/// </summary>
public class ButtonTransition : MonoBehaviour
{
    public string id;
    private Button btn;
    
    private void Awake() =>  btn.onClick.AddListener(delegate { Transition();});

    private void Transition() => WindowAgregator.SetWindowHandler(id);
}
