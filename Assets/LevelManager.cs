using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    Transform _origin;

    public void Init(Transform origin)
    {
        _origin.transform.position = origin.transform.position;
        _origin.parent = origin;
    }
}
