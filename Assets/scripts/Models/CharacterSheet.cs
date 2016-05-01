using System;

namespace Character_Information
{
    public class CharacterSheet
    {
        public enum BASE_CLASSES { KNIGHT, ARCHER, SCOUT, MAGE };
        public enum FOCUS_TYPES {FIRE, WATER, EARTH, AIR, LIGHT, DARK };
        /// <summary>
        /// Creates a randomized character with a given name
        /// </summary>
        /// <param name="name">name of the character</param>
        public CharacterSheet(string name)
        {
            characterName = name;
            Random randomGenerator = new Random();
            UnityEngine.Texture2D tex = UnityEngine.Resources.Load("DefaultPortrait") as UnityEngine.Texture2D;
            portrait = UnityEngine.Sprite.Create(tex, new UnityEngine.Rect(0, 0, tex.width, tex.height), UnityEngine.Vector2.zero);
            baseClass = (BASE_CLASSES)randomGenerator.Next(0, 4);
            switch (baseClass)
            {
                case BASE_CLASSES.KNIGHT:
                    new BASE_KNIGHT(this);
                    break;
                case BASE_CLASSES.ARCHER:
                    new BASE_ARCHER(this);
                    break;
                case BASE_CLASSES.SCOUT:
                    new BASE_SCOUT(this);
                    break;
                case BASE_CLASSES.MAGE:
                    new BASE_MAGE(this);
                    break;
            }
            focusType = (FOCUS_TYPES)randomGenerator.Next(0, 6);
        }
        public UnityEngine.Sprite portrait;
        public string className;
        private BASE_CLASSES baseClass;
        public string characterName;
        public bool isAdvanced;

        #region Character Stats
        public CharacterResource healthPoints;
        public CharacterResource skillPoints;
        public CharacterResource actionPoints;
        public CharacterStat strength;
        public CharacterStat toughness;
        public CharacterStat accuracy;
        public CharacterStat wisdom;
        public CharacterStat resistance;
        public CharacterStat luck;
        #endregion
        #region Character Effectors
        private FOCUS_TYPES focusType;
        private int fatigue;
        private int stress;
        #endregion
        #region Hidden Stats
        private int toxicity;
        private int toxicityLevel;
        private int darkGrip;
        private int darkLevel;
        #endregion
        /// <summary>
        /// Gets a debug list of character attributes
        /// </summary>
        /// <returns>formatted string of attributes</returns>
        public string PrintCharacterVitals()
        {
            string outDebug = string.Format("Character Name: {0}\nClass Name: {1}\nHP: {2}\nSP: {3}\nAP: {4}\nSTR: {5}\nTGH: {6}\nACC: {7}\nWIS: {8}\nRES: {9}\nLCK: {10}", characterName, className, healthPoints.getStat(),
                                                                                                                                                                            skillPoints.getStat(), actionPoints.getStat(), strength.getStat(), 
                                                                                                                                                                            toughness.getStat(), accuracy.getStat(), wisdom.getStat(), 
                                                                                                                                                                            resistance.getStat(), luck.getStat());
            return outDebug;
        }
    }
    public class BASE_CLASS
    {
        protected int HP;
        protected int SP;
        protected int AP;
        protected int STR;
        protected int TGH;
        protected int ACC;
        protected int WIS;
        protected int RES;
        protected int LCK;

        protected void AssignBaseStatSheet(CharacterSheet outSheet)
        {
            outSheet.healthPoints = new CharacterResource(HP, CharacterStat.STATE_TYPE.HP);
            outSheet.skillPoints = new CharacterResource(SP, CharacterStat.STATE_TYPE.SP);
            outSheet.actionPoints = new CharacterResource(AP, CharacterStat.STATE_TYPE.AP);
            outSheet.strength = new CharacterStat(STR, CharacterStat.STATE_TYPE.STR);
            outSheet.toughness = new CharacterStat(TGH, CharacterStat.STATE_TYPE.TGH);
            outSheet.accuracy = new CharacterStat(ACC, CharacterStat.STATE_TYPE.ACC);
            outSheet.wisdom = new CharacterStat(WIS, CharacterStat.STATE_TYPE.WIS);
            outSheet.resistance = new CharacterStat(RES, CharacterStat.STATE_TYPE.RES);
            outSheet.luck = new CharacterStat(LCK, CharacterStat.STATE_TYPE.LCK);
        }
    }
    public class BASE_KNIGHT : BASE_CLASS
    {
        public BASE_KNIGHT(CharacterSheet sheet)
        {
            HP = 100;
            SP = 15;
            AP = 4;
            STR = 15;
            TGH = 10;
            ACC = 10;
            WIS = 5;
            RES = 15;
            LCK = 5;
            sheet.className = "Knight";
            AssignBaseStatSheet(sheet);

        }
    }
    public class BASE_ARCHER : BASE_CLASS
    {
        public BASE_ARCHER(CharacterSheet sheet)
        {
            HP = 40;
            SP = 20;
            AP = 4;
            STR = 10;
            TGH = 10;
            ACC = 30;
            WIS = 15;
            RES = 5;
            LCK = 10;
            sheet.className = "Archer";
            AssignBaseStatSheet(sheet);

        }
    }
    public class BASE_SCOUT : BASE_CLASS
    {
        public BASE_SCOUT(CharacterSheet sheet)
        {
            HP = 60;
            SP = 30;
            AP = 4;
            STR = 10;
            TGH = 20;
            ACC = 15;
            WIS = 10;
            RES = 20;
            LCK = 7;
            sheet.className = "Scout";
            AssignBaseStatSheet(sheet);
        }
    }
    public class BASE_MAGE : BASE_CLASS
    {
        public BASE_MAGE(CharacterSheet sheet)
        {
            HP = 50;
            SP = 5;
            AP = 4;
            STR = 5;
            TGH = 5;
            ACC = 20;
            WIS = 30;
            RES = 5;
            LCK = 5;
            sheet.className = "Mage";
            AssignBaseStatSheet(sheet);
        }
    }

    
}
