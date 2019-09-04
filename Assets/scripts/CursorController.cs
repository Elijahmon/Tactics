using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    [SerializeField]
    LayerMask _selectionLayer;
    [SerializeField]
    Camera _selectionCamera;
    [SerializeField]
    LayerMask _moveLayer;
    

    public CharacterStateController _selectedCharacter;
    private CharacterUIController _characterInfo;
    private Transform _cursorParent;
    private bool updateUI = true;

    void LeftClick()
    {
    }

    void RightClick()
    {
    }
}
