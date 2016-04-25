using UnityEngine;
using System.Collections;
using Character_Information;

public class CharacterSheetTester : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CharacterSheet myChar = new CharacterSheet("Bilbo");
       // Debug.Log(myChar.className);
        Debug.Log(myChar.PrintCharacterVitals());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
