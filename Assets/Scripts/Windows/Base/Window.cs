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
    public Action RefreshWindowHandler = delegate { };
    public bool Focus;

    private IAnimationWindow animation;
    private Action handlerClose = delegate { };
    /// <summary>
    /// Что делаем при открытии окна
    /// </summary>
    public virtual void OnEnable()
    {
        OnOpen();
    }

    private void Awake()
    {
        animation = GetComponent<IAnimationWindow>();
        handlerClose += CloseEvent;
    }

    private void OnDestroy()
    {
        handlerClose -= CloseEvent;
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

    /// <summary>
    /// Закрытие окна. Вызывается по кнопке ButtonClose либо по клавише.
    /// </summary>
    public void OnClose()
    {

        if (animation != null)
        {
            animation.OnCloseWinodwAnim(handlerClose);
        }
        else
        {
            WindowAgregator.RemoveWindowHandler(this);
        }
    }

    private void CloseEvent()
    {
        WindowAgregator.RemoveWindowHandler(this);
    }
}