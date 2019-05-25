using System.Collections.Generic;
using UnityEngine;

using System;
/// <summary>
/// Класс, управляющий спауном нужных окон
/// </summary>
public class WindowAgregator : MonoBehaviour
{
    public static Action<string> SetWindowHandler = delegate { };
    public static Action<Window> AddWindowHandler = delegate { };
    public static Action<Window> RemoveWindowHandler = delegate { };

    public List<Window> WindowsInMemory = new List<Window>();
    private Canvas canvas;

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
            WindowsInMemory.Add(startWindow);
        }
        catch (Exception e)
        {
            Debug.LogError("Не найден объект стартовой точки для данной сцены.");
            Debug.LogError(e.Message);
        }
    }


    /// <summary>
    /// Выгружаем из памяти нужное окно
    /// </summary>
    private void OnSetWindowHanlder(string inputId)
    {
        Window newWindow = new Window();
        newWindow = Resources.Load<Window>("ScenesWindows/" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name +"/"+inputId);
        newWindow = Instantiate<Window>(newWindow, canvas.transform);
        
    }

    private void OnAddingWindowHandler(Window window)
    {
        WindowsInMemory.Add(window);
    }

    private void OnRemovingWindowHandler(Window window)
    {
        //Мы не можем удалить самое первое окно интерфейса.
        if (WindowsInMemory.Count > 1)
        {
            WindowsInMemory.Remove(window);
            Destroy(window.gameObject);
        }
    }
}
