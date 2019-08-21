// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UIS;

/// <summary>
/// Main class container
/// </summary>
public class WindowAgregator : MonoBehaviour
{
    public enum TypeLoad
    {
        ResourceLoad,
        InspectorLoad
    }

    public TypeLoad StateLoad;

    public static Action<string> SetWindowHandler = delegate { };
    public static Action<Window> AddWindowHandler = delegate { };
    public static Action<Window> RemoveWindowHandler = delegate { };


    [Header("Canvas:")]
    public Canvas Canvas;

    [Header("Стартовое окно интерфейса:")] public WindowAsset StartWindow;
    [Header("Active windows:")] public List<Window> WindowsInHistory = new List<Window>();

    [Header("Windows in pool:")] public List<Window> WindowsPool = new List<Window>();

    private ILoadableWindow _loadManager;

    private void OnEnable()
    {
        SetWindowHandler += OnSetWindowHanlder;
        AddWindowHandler += OnAddingWindowHandler;
        RemoveWindowHandler += OnRemovingWindowHandler;
    }

    private void Awake()
    {
        CreateInterface();
        SelectLoadType();
    }

    private void SelectLoadType()
    {
        switch (StateLoad)
        {
            case TypeLoad.InspectorLoad:
                {
                    _loadManager = gameObject.GetComponent<LoadWindowInspector>();
                    if (_loadManager == null)
                    {
                        Debug.LogError(
                            "Add component LoadWindowInspector or sets your assets windows for this scene!");
                    }

                    break;
                }

            case TypeLoad.ResourceLoad:
                {
                    _loadManager = gameObject.AddComponent<LoadWindowResource>();
                    break;
                }

            default:
                {
                    _loadManager = gameObject.AddComponent<LoadWindowResource>();
                    break;
                }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && WindowsInHistory.Count > 1)
        {
            WindowsInHistory[WindowsInHistory.Count - 1].OnClose();
        }
    }

    private void OnDisable()
    {
        SetWindowHandler -= OnSetWindowHanlder;
        AddWindowHandler -= OnAddingWindowHandler;
        RemoveWindowHandler -= OnRemovingWindowHandler;
    }

    /// <summary>
    /// Load custom canvas then scene starts
    /// </summary>
    private void CreateInterface()
    {
        Canvas = Instantiate(Canvas, transform);
        try
        {
            var startWindow = StartWindow.Window;
            startWindow = Instantiate(startWindow, Canvas.transform);
            startWindow.IdWindow = StartWindow.name;
            WindowsInHistory.Add(startWindow);
        }
        catch (Exception e)
        {
            Debug.LogError("Not found start asset window.");
            Debug.LogError(e.Message);
        }
    }

    /// <summary>
    /// Unload the necessary window from memory and determine whether the previous window should be turned off.
    /// </summary>
    private void OnSetWindowHanlder(string idWindow)
    {
        var newWindow = SearchWindowInPool(idWindow);
        //If the item is not in the pool and not in the active window history, then spawn.
        if (!HasWindowExist(idWindow))
        {
            var spawnWindow = _loadManager.GetWindowAsset(idWindow);
            if (spawnWindow)
            {
                newWindow = Instantiate(spawnWindow.Window, Canvas.transform);
                newWindow.IdWindow = idWindow;
                newWindow.name = spawnWindow.name;
            }
                
            else
            {
                Debug.LogError("Не найден ассет окна с  id = " + idWindow);
            }
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
        if (!WindowsInHistory.SingleOrDefault(obj => obj.IdWindow == window.IdWindow))
        WindowsInHistory.Add(window);
    }

    private void OnRemovingWindowHandler(Window window)
    {
        //We cannot delete the very first interface window.
        if (WindowsInHistory.Count <= 1) return;
        window.gameObject.SetActive(false);
        WindowsInHistory.Remove(window);
        //If the previous window was turned off by the rules, we turn it on (going back through the window history).
        WindowsInHistory[WindowsInHistory.Count - 1].gameObject.SetActive(true);
        //Activate the focus of the window back, allowing it a series of indicated actions.
        WindowsInHistory[WindowsInHistory.Count - 1].Focus = true;
        WindowsPool.Add(window);
    }

    private Window SearchWindowInPool(string idWindow)
    {
        return WindowsPool.SingleOrDefault(obj => obj.name == idWindow);
    }

    private bool HasWindowExist(string idWindow)
    {
        return WindowsInHistory.SingleOrDefault(obj => obj.name == idWindow) ||
               WindowsPool.SingleOrDefault(obj => obj.name == idWindow);
    }
}
