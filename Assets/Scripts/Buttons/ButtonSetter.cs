using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonSetter : MonoBehaviour
{
    [HideInInspector]
    public Button button;

    public virtual void Awake()
    {
        button = GetComponent<Button>();
        if (!button)
        {
            Destroy(this);
        }
    }

    public virtual void Start() => button.onClick.AddListener(delegate { Action(); });

    public virtual void Action()
    {

    }
}
