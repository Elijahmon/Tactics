using UnityEngine;
using System.Collections;
using Character_Information;

public class CharacterStateController : MonoBehaviour {

    public enum CHARACTER_STATE {IDLE, SELECTED, ACTING, DOWN, DEAD};

    [SerializeField]
    private static int UNIQUE_ID; //A Unique NPC is named and has specific stats or is tied to a save at a later point 0 is a randomized test character

    private CHARACTER_STATE _myState;
    public bool myturn;
    private CharacterSheet _mySheet;
    private NavMeshAgent _myAgent;

	// Use this for initialization
	void Awake ()
    {
        if(UNIQUE_ID == 0)
        {
            _mySheet = new CharacterSheet("TestCharacter");
        }
        _myAgent = this.GetComponent<NavMeshAgent>();
	}

    /// <summary>
    /// gets this characters character sheet
    /// </summary>
    /// <returns>CharacterSheet object</returns>
    public CharacterSheet getSheet()
    {
        return _mySheet;
    }
    /// <summary>
    /// gets this characters character sheet
    /// </summary>
    /// <returns>enum of state (0-4)</returns>
    public CHARACTER_STATE getState()
    {
        return _myState;
    }
    /// <summary>
    /// Sets a new destination for the navmesh agent
    /// </summary>
    /// <param name="dest">the point to move to</param>
    public void SetNewDestination(Vector3 dest)
    {
        _myAgent.destination = dest;
    }
}
