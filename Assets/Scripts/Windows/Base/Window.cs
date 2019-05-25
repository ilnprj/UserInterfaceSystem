using UnityEngine;

/// <summary>
/// Родительский класс Окна, реализует интерфейс IWindow
/// </summary>
public class Window : MonoBehaviour, IWindow
{
    public bool Focus;

    public virtual void OnEnable()
    {
        OnOpen();
    }

    /// <summary>
    /// По открытию окна заносим его в лист агрегатора окон.
    /// </summary>
    public void OnOpen()
    {
        WindowAgregator.AddWindowHandler(this);
        Focus = true;
    }

#if UNITY_STANDALONE
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Focus)
        {
            this.OnClose();
        }
    }
#endif

    /// <summary>
    /// Закрытие окна. Вызывается по кнопке ButtonClose либо по клавише.
    /// </summary>
    public void OnClose()
    {
        WindowAgregator.RemoveWindowHandler(this);
    }
}
