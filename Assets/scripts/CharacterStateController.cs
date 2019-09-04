using UnityEngine;
using System.Collections;
using Character_Information;

public class CharacterStateController : MonoBehaviour {

    public enum CHARACTER_STATE {IDLE, SELECTED, ACTING, DOWN, DEAD};

    private CHARACTER_STATE _myState;
    private CharacterSheet _mySheet;

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
}
