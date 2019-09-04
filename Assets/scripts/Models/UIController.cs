using UnityEngine;
using UnityEngine.UI;

public abstract class UIController : MonoBehaviour
{

    /// <summary>
    /// Used to show or hide the UI associated with this controller by enabling the canvas
    /// </summary>
    /// <param name="toggle">show(true) or hide(false) the UI element</param>
    public virtual void ToggleVisibility(bool toggle)
    {
        gameObject.SetActive(toggle);
    }

    /// <summary>
    /// Run in Start method attempts to assign canvas
    /// </summary>
    /// <returns>true if canvas is assigned false if not</returns>
    public virtual void Init()
    {
    }
}
