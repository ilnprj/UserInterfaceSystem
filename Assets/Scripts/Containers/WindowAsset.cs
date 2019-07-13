using UnityEngine;

/// <summary>
/// Ассет окна, может хранить в себе как и префаб, так и остальные необходимые объекты для него.
/// </summary>
[CreateAssetMenu(menuName = "Windows/Create New Asset Window", fileName = "AssetWindow", order = 0)]
public class WindowAsset : ScriptableObject
{
    [SerializeField] 
    private Window window;

    public Window Window => window;
}
