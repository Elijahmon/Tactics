using System.Collections.Generic;
using Buff_Debuff;

public class CharacterStat
{
    public enum STATE_TYPE {HP, LCK}
    /// <summary>
    /// Constructor takes in stat base setting and name
    /// </summary>
    /// <param name="baseStat">base value that will always exist</param>
    /// <param name="statName">name of the stat</param>
    public CharacterStat(int baseStat, STATE_TYPE statType)
    {
        type = statType;
        baseAmount = baseStat;
        switch(type)
        {
            case STATE_TYPE.HP:
                name = "Health Points";
                description = "The amount of damage this character can take before being downed.";
                break;
            case STATE_TYPE.LCK:
                name = "Luck";
                description = "Increases likelihood of critical strikes and critical saves.";
                break;
        }
    }


    #region Stats
    public string name;
    public string description;
    protected int baseAmount = 0;
    protected int bonusAmount = 0;
    protected List<Buff> buffs = new List<Buff>();
    protected List<Debuff> debuffs = new List<Debuff>();
    protected STATE_TYPE type;
    #endregion

    #region Getters
    /// <summary>
    /// returns the stored amount of the stat
    /// </summary>
    /// <returns>integer amount of stat</returns>
    public int GetStat()
    {
        return (baseAmount + bonusAmount);
    }
    #endregion
    /// <summary>
    /// Modifies the stat by the given amount
    /// </summary>
    public virtual void ModifyStat(int mod)
    {

    }

    /// <summary>
    /// Applies a buff to the stat or stacks on top of existing buff (diminishing returns)
    /// </summary>
    /// <param name="buff">buff to apply</param>
    public void BuffStat(Buff buff)
    {
    }

    /// <summary>
    /// Applies a debuff to the stat or stacks on existing ones (diminishing returns)
    /// </summary>
    /// <param name="buff"></param>
    public void DebuffStat(Debuff buff)
    {
    }



}
