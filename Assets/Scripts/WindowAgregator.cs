using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс, управляющий спауном нужных окон
/// </summary>
public class WindowAgregator : MonoBehaviour
{
    public static Action<string> SetWindowHandler = delegate { };
    public static Action<Window> AddWindowHandler = delegate { };
    public static Action<Window> RemoveWindowHandler = delegate { };

    [Header("Предварительно настроенный Canvas:")]
    public Canvas Canvas;
    [Header("Стартовое окно интерфейса:")] 
    public WindowAsset StartWindow;
    [Header("Активные окна:")]
    public List<Window> WindowsInHistory = new List<Window>();

    [Header("Окна в пуле:")]
    public List<Window> WindowsPool = new List<Window>();

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

#if UNITY_STANDALONE
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (WindowsInHistory.Count>1)
            WindowsInHistory[WindowsInHistory.Count-1].OnClose();
    }
#endif

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
        Canvas = Instantiate(Canvas, transform);
        try
        {
            var startWindow = StartWindow.Window;
            startWindow = Instantiate(startWindow, Canvas.transform);
            startWindow.name = StartWindow.name;
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
        var newWindow = SearchWindowInPool(idWindow);
        //Если элемента нет в пуле и нет в активной истории окон то спауним.
        if (!HasWindowExist(idWindow))
        {
            var spawnWindow = Resources.Load<WindowAsset>("WindowAssets/"+SceneManager.GetActiveScene().name+"/"+idWindow);
            newWindow = Instantiate(spawnWindow.Window, Canvas.transform);
            newWindow.name = spawnWindow.name;
        }
        else
        {
            if (newWindow == null) return;
            WindowsPool.Remove(newWindow);
            newWindow.gameObject.SetActive(true);
        }
    }

    private void OnAddingWindowHandler(Window window)
    {
        WindowsInHistory.Add(window);
    }

    private void OnRemovingWindowHandler(Window window)
    {
        //Мы не можем удалить самое первое окно интерфейса.
        if (WindowsInHistory.Count <= 1) return;
        window.gameObject.SetActive(false);
        WindowsInHistory.Remove(window);
        //Если предыдущее окно по правилам было выключено, мы включаем его (возвращаясь назад по истории окон).
        WindowsInHistory[WindowsInHistory.Count-1].gameObject.SetActive(true);
        //Активируем фокус окна обратно, позволяя ему ряд обозначенных действий
        WindowsInHistory[WindowsInHistory.Count - 1].Focus = true;
        WindowsPool.Add(window);
    }

    private Window SearchWindowInPool(string idWindow)
    {
        return WindowsPool.SingleOrDefault(obj => obj.name == idWindow);
    }

    private bool HasWindowExist(string idWindow)
    {
        return WindowsInHistory.SingleOrDefault(obj => obj.name == idWindow) || WindowsPool.SingleOrDefault(obj => obj.name == idWindow);
    }
}
