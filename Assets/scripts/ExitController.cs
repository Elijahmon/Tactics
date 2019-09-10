using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    LevelManager _manager;
    bool open;

    public void Init(LevelManager levelManager)
    {
        _manager = levelManager;
        ToggleActive(false);
    }

    public void ToggleActive(bool toggle)
    {
        gameObject.SetActive(toggle);
        open = toggle;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (open)
        {
            if (collider.transform.tag == "Player")
            {
                _manager.ExitReached(collider.GetComponent<PlayerCharacterController>());
            }
        }
    }
}
