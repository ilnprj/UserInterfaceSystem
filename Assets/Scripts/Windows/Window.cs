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

    /// <summary>
    /// В данных методах мы можем дополнительно реализовать решения которые будут распространяться на все остальные окна
    /// </summary>
    public void OnOpen()
    {
        WindowAgregator.AddWindowHandler(this);
    }

#if UNITY_STANDALONE
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClose();
        }
    }
#endif

    public void OnClose()
    {
        WindowAgregator.RemoveWindowHandler(this);
    }
}
