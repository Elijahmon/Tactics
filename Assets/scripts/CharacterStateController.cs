using UnityEngine;
using System.Collections;
using Character_Information;

public class CharacterStateController : MonoBehaviour {

    public enum CHARACTER_STATE {IDLE, SELECTED, ACTING, DOWN, DEAD};

    [SerializeField]
    private static int UNIQUE_ID; //A Unique NPC is named and has specific stats or is tied to a save at a later point 0 is a randomized test character

    private CHARACTER_STATE _myState;
    private bool _myturn;
    private CharacterSheet _mySheet;

	// Use this for initialization
	void Start ()
    {
        if(UNIQUE_ID == 0)
        {
            _mySheet = new CharacterSheet("TestCharacter");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public CharacterSheet getSheet()
    {
        return _mySheet;
    }
}
