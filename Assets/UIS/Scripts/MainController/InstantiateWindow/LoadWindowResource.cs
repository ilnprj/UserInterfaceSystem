namespace UIS
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// Class that loads the Assets of the windows previously unloaded from SO
    /// </summary>
    public class LoadWindowResource : MonoBehaviour, ILoadableWindow
    {
        public WindowAsset GetWindowAsset(string idWindow)
        {
            return Resources.Load<WindowAsset>("WindowAssets/" + SceneManager.GetActiveScene().name + "/" + idWindow);
        }
    }
}
