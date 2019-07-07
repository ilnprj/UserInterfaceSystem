using UnityEngine;

[CreateAssetMenu(menuName = "Windows/Create New Asset Window", fileName = "AssetWindow", order = 0)]
public class WindowAsset : ScriptableObject
{
    [SerializeField] 
    private Window window;
    [SerializeField]
    private string id;

    public Window Window
    {
        get => window;
    }

    public string Id
    {
        get => id;
    }
}
