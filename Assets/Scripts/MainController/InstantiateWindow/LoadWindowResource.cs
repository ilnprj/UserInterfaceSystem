using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class LoadWindowResource : MonoBehaviour, ILoadableWindow
{
    public WindowAsset GetWindowAsset(string idWindow)
    {
        return Resources.Load<WindowAsset>("WindowAssets/"+SceneManager.GetActiveScene().name+"/"+idWindow);
    }
}
