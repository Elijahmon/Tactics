using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItemController : MonoBehaviour
{
    LevelManager _manager;
    bool lootAble;

    public void Init(LevelManager levelManager)
    {
        _manager = levelManager;
        ToggleActive(true);
    }

    public void ToggleActive(bool toggle)
    {
        lootAble = toggle;
        gameObject.SetActive(toggle);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _manager.LootItemAquired(this);
        }
    }
}
