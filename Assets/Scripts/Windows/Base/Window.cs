using UnityEngine;
using System;

/// <summary>
/// Родительский класс Окна, реализует интерфейс IWindow
/// </summary>
public class Window : MonoBehaviour, IWindow
{
    /// <summary>
    /// Если по обновлению окна, нужно обновить элементы, мы подписываемся на данный Handler
    /// </summary>
    public Action RefreshWindowHandler = delegate {};
    public bool Focus;
    
    /// <summary>
    /// Что делаем при открытии окна
    /// </summary>
    public virtual void OnEnable()
    {
        OnOpen();
    }

    public virtual void OnRefresh()
    {
        RefreshWindowHandler.Invoke();
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
