using UnityEngine;
using System.Collections;

public class CharacterUIController : UIController {

    

	// Use this for initialization
	void Start ()
    {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected override bool Initialize()
    {
        bool ret = base.Initialize();
        //Additional Initialization here
        return ret;
    }
}
