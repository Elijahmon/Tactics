using System.Collections;
using System.Collections.Generic;
using Character_Information;

public class Player
{
    public Player(string _name)
    {
        name = _name;
        characters = new List<CharacterSheet>();
        characters.Add(new CharacterSheet(name));
    }

    string name;
    List<CharacterSheet> characters;

}
