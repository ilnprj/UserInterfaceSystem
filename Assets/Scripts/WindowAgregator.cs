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
    
    private void OnEnable()
    {
        CreateCanvas();
    }

    private void OnDisable()
    {
        
    }

    private void LoadStartWindow()
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
    private void CreateCanvas()
    {
        GameObject gameObject = Resources.Load<GameObject>("Canvas");
        gameObject = Instantiate(gameObject, this.transform);
        
    }
}
