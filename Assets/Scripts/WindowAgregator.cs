using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class WindowAgregator : MonoBehaviour
{
    public static System.Action<string> SetWindowHandler = delegate { };
    public List<GameObject> WindowsInMemory = new List<GameObject>();
    
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

    private void CreateCanvas()
    {
        GameObject gameObject = Resources.Load<GameObject>("Canvas");
        gameObject = Instantiate(gameObject, this.transform);
        
    }
}
