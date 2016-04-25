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
    private Transform _cursorParent;
    

    void Awake()
    {
        _cursorParent = this.GetComponent<RectTransform>();

    }

    void Update()
    {
        
        _cursorParent.transform.position = Input.mousePosition;
        if(Input.GetButtonDown(InputReference.LMB))
        {
            LeftClick();
        }
        if(Input.GetButtonDown(InputReference.RMB))
        {
            RightClick();
        }
        
    }

    void LeftClick()
    {
        RaycastHit hit;

        if (Physics.Raycast(_selectionCamera.ScreenPointToRay(Input.mousePosition), out hit, 100f, _selectionLayer))
        {
            CharacterStateController hitCont = hit.collider.GetComponent<CharacterStateController>();
            if(hitCont != null)
            {
                _selectedCharacter = hitCont;
            }
        }
    }

    void RightClick()
    {
        if(_selectedCharacter != null)
        {
            RaycastHit hit;

            if (Physics.Raycast(_selectionCamera.ScreenPointToRay(Input.mousePosition), out hit, 100f, _moveLayer))
            {
                _selectedCharacter.SetNewDestination(hit.point);
            }
        }
    }
}
