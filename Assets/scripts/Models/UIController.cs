using UnityEngine;
using UnityEngine.UI;

public abstract class UIController : MonoBehaviour
{
    [SerializeField]
    protected Canvas _renderCanvas;

    protected bool active;


    /// <summary>
    /// Used to show or hide the UI associated with this controller by enabling the canvas
    /// </summary>
    /// <param name="show">show(true) or hide(false) the UI element</param>
    /// <returns>true if a change was made false if not</returns>
    public virtual bool ShowHide(bool show)
    {
        if(active != show)
        {
            active = show;
            _renderCanvas.enabled = active;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Run in Start method attempts to assign canvas
    /// </summary>
    /// <returns>true if canvas is assigned false if not</returns>
    protected virtual bool Initialize()
    {
        _renderCanvas = this.GetComponentInParent<Canvas>();
        return _renderCanvas != null ? true : false;
    }
}
