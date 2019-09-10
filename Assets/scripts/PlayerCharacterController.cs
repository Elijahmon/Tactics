using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rigidbody;
    [SerializeField]
    Collider _coll;
    [SerializeField]
    NavMeshAgent _nav;
    [SerializeField]
    GameObject selection;

    public void Init()
    {
        ToggleSelectionVisible(false);
    }

    public void SetNewDestination(Vector3 position)
    {
        _nav.SetDestination(position);
    }
    
    public void ToggleSelectionVisible(bool toggle)
    {
        selection.SetActive(toggle);
    }

}
