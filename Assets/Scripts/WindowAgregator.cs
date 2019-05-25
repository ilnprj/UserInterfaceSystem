using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, управляющий спауном нужных окон
/// </summary>
public class WindowAgregator : MonoBehaviour
{
    public static System.Action<string> SetWindowHandler = delegate { };
    public List<Window> WindowsInMemory = new List<Window>();
    private Canvas canvas;

    private void Awake()
    {
        CreateInterface();
    }

    private void OnDisable()
    {
        
    }
    /// <summary>
    /// Выгружаем из памяти нужное окно
    /// </summary>
    private void OnSetWindowHanlder(string inputId)
    {

    }

    /// <summary>
    /// Загружаем канвас.
    /// </summary>
    private void CreateInterface()
    {
        canvas = Resources.Load<Canvas>("Canvas");
        canvas = Instantiate(canvas, this.transform);

        StartWindow sObject = Resources.Load<StartWindow>("StartPoints/Menu");
        Window startWindow = sObject.GetWindow;
        startWindow = Instantiate<Window>(startWindow, canvas.transform);
        WindowsInMemory.Add(startWindow);
    }
}
