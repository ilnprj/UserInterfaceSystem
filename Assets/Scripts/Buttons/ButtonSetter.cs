using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonSetter : MonoBehaviour
{
    [HideInInspector]
    public Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (!button)
        {
            Destroy(this);
        }
    }
}
