using System;

namespace Character_Information
{
    public class CharacterSheet
    {
        public enum CLASS { THEIF };
        /// <summary>
        /// Creates a randomized character with a given name
        /// </summary>
        /// <param name="name">name of the character</param>
        public CharacterSheet(string name)
        {
            characterName = name;
            Random randomGenerator = new Random();
        }

        public string characterName;

        #region Character Stats
        public CharacterResource healthPoints;
        public CharacterStat luck;
        #endregion
        #region Hidden Stats
        #endregion
    }
    public class BASE_CLASS
    {
        protected int HP;
        protected int LCK;

        protected void AssignBaseStatSheet(CharacterSheet outSheet)
        {
            outSheet.healthPoints = new CharacterResource(HP, CharacterStat.STATE_TYPE.HP);
            outSheet.luck = new CharacterStat(LCK, CharacterStat.STATE_TYPE.LCK);
        }
    }
    
}
