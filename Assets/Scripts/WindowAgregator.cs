using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// Класс, управляющий спауном нужных окон
/// </summary>
public class WindowAgregator : MonoBehaviour
{
    public static Action<string> SetWindowHandler = delegate { };
    public static Action<Window> AddWindowHandler = delegate { };
    public static Action<Window> RemoveWindowHandler = delegate { };

    [Header("Активные окна:")]
    public List<Window> WindowsInHistory = new List<Window>();

    [Header("Окна в пуле:")]
    public List<Window> WindowsPool = new List<Window>();

    private Canvas canvas = null;
    
    private void OnEnable()
    {
        SetWindowHandler += OnSetWindowHanlder;
        AddWindowHandler += OnAddingWindowHandler;
        RemoveWindowHandler += OnRemovingWindowHandler;
    }

    private void Awake()
    {
        CreateInterface();
    }

    private void OnDisable()
    {
        SetWindowHandler -= OnSetWindowHanlder;
        AddWindowHandler -= OnAddingWindowHandler;
        RemoveWindowHandler -= OnRemovingWindowHandler;
    }

    /// <summary>
    /// Загружаем canvas при старте сцены.
    /// </summary>
    private void CreateInterface()
    {
        canvas = Resources.Load<Canvas>("ScenesWindows/Canvas");
        canvas = Instantiate(canvas, this.transform);
        try
        {
            StartWindow sObject = Resources.Load<StartWindow>("StartPoints/" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            Window startWindow = sObject.GetWindow;
            startWindow = Instantiate<Window>(startWindow, canvas.transform);
            startWindow.name = sObject.GetWindow.gameObject.name;
            WindowsInHistory.Add(startWindow);
        }
        catch (Exception e)
        {
            Debug.LogError("Не найден объект стартовой точки для данной сцены.");
            Debug.LogError(e.Message);
        }
    }

    /// <summary>
    /// Выгружаем из памяти нужное окно и определяем надо ли выключить предыдущее окно
    /// </summary>
    private void OnSetWindowHanlder(string idWindow)
    {
        Window newWindow = new Window();
        newWindow = SearchWindowInPool(idWindow);
        //Если элемента нет в пуле и нет в активной истории окон то спауним.
        if (!HasWindowExist(idWindow))
        {
            Window spawnWindow = Resources.Load<Window>("ScenesWindows/" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + "/" + idWindow);
            newWindow = Instantiate<Window>(spawnWindow, canvas.transform);
            newWindow.name = spawnWindow.name;
        }
        else
        {
            if (newWindow!=null)
            {
                WindowsPool.Remove(newWindow);
                newWindow.gameObject.SetActive(true);
            }
        }
    }

    private void OnAddingWindowHandler(Window window)
    {
        WindowsInHistory.Add(window);
    }

    private void OnRemovingWindowHandler(Window window)
    {
        //Мы не можем удалить самое первое окно интерфейса.
        if (WindowsInHistory.Count > 1)
        {
            window.gameObject.SetActive(false);
            WindowsInHistory.Remove(window);
            //Если предыдущее окно по правилам было выключено, мы включаем его (возвращаясь назад по истории окон).
            WindowsInHistory[WindowsInHistory.Count-1].gameObject.SetActive(true);
            //Активируем фокус окна обратно, позволяя ему ряд обозначенных действий
            WindowsInHistory[WindowsInHistory.Count - 1].Focus = true;
            WindowsPool.Add(window);
        }
    }

    private Window SearchWindowInPool(string idWindow)
    {
        return WindowsPool.Where(obj => obj.name == idWindow).SingleOrDefault();
    }

    private bool HasWindowExist(string idWindow)
    {
        return (WindowsInHistory.Where(obj => obj.name == idWindow).SingleOrDefault() || WindowsPool.Where(obj => obj.name == idWindow).SingleOrDefault());
    }
}
