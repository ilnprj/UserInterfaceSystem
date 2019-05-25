using UnityEngine;
/// <summary>
/// Родительский класс Окна, реализует интерфейс IWindow
/// </summary>
public class Window : MonoBehaviour, IWindow
{
    public string idWindow;

    public virtual void OnEnable()
    {
        OnOpen();
    }

    public virtual void OnDestroy()
    {
        OnClose();
    }


    /// <summary>
    /// В данных методах мы можем дополнительно реализовать решения которые будут распространяться на все остальные окна
    /// </summary>
    public void OnOpen()
    {
        Debug.Log("OnOpen");
    }

    public void OnClose()
    {
        Debug.Log("OnClose");
    }
}
