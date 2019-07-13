using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Класс, загружающий Ассеты окон, предварительно выгруженные в инспектор.
/// </summary>
public class LoadWindowInspector : MonoBehaviour, ILoadableWindow
{
    public List<WindowAsset> WindowsForScene = new List<WindowAsset>();
    public WindowAsset GetWindowAsset(string idWindow)
    {
        return WindowsForScene.SingleOrDefault(obj => obj.name == idWindow);
    }
}
