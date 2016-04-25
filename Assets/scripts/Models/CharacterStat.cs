using System.Collections.Generic;
using Buff_Debuff;

public class CharacterStat
{
    public enum STATE_TYPE {HP, SP, AP, STR, TGH, ACC, WIS, RES, LCK}
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
            case STATE_TYPE.SP:
                name = "Skill Points";
                description = "Resource used when activating skills.";
                break;
            case STATE_TYPE.AP:
                name = "Action Points";
                description = "Resource used to take actions during turns";
                break;
            case STATE_TYPE.STR:
                name = "Strength";
                description = "Affects the amount of damage this character does with basic attacks.";
                break;
            case STATE_TYPE.TGH:
                name = "Toughness";
                description = "Reduces the damage from basic attacks and the effects of status effects.";
                break;
            case STATE_TYPE.ACC:
                name = "Accuracy";
                description = "Modifies the liklihood of this characters skills and basic attacks hitting their target.";
                break;
            case STATE_TYPE.WIS:
                name = "Wisdom";
                description = "Affects the amount of damage this character does with skills.";
                break;
            case STATE_TYPE.RES:
                name = "Resistance";
                description = "Reduces the damage from skills and the likelihood of being affected by status effects.";
                break;
            case STATE_TYPE.LCK:
                name = "Luck";
                description = "Increases likelihood of critical strikes and critical saves.";
                break;
        }
    }


    #region Accessable Information
    public string name;
    public string description;
    protected int baseAmount = 0;
    protected int bonusAmount = 0;
    protected int buffAmount;
    protected bool isBuffed;
    protected bool isDebuffed;
    protected List<Buff> buffs = new List<Buff>();
    protected List<Debuff> debuffs = new List<Debuff>();
    #endregion
    protected STATE_TYPE type;
    protected int min;
    protected int falloff;
    protected int partials;

    /// <summary>
    /// returns the stored amount of the stat
    /// </summary>
    /// <returns>integer amount of stat</returns>
    public int getStat()
    {
        return (baseAmount + bonusAmount + buffAmount);
    }
    /// <summary>
    /// returns the amount stat is currently buffed by
    /// </summary>
    /// <returns>integer amount (can be negative)</returns>
    public int getBuffAmount()
    {
        return buffAmount;
    }
    /// <summary>
    /// Modifies the stat by the given amount (past falloff will only mod half value)
    /// </summary>
    /// <param name="mod">amounr to modify stat by (can be negative)</param>
    /// <returns>returns 0 for lowered stat and 1 for increased stat</returns>
    public virtual int modifyStat(int mod)
    {
        if (mod <= 0)
        {
            if (bonusAmount + mod < min)
            {
                bonusAmount = min;
                return 0;
            }
        }
        if ((bonusAmount + baseAmount) + mod > falloff)
        {
            partials = mod;
            bonusAmount += partials / 2;
            return 1;
        }
        else
        {
            bonusAmount += mod;
            return 1;
        }
    }
    /// <summary>
    /// Applies a buff to the stat or stacks on top of existing buff (diminishing returns)
    /// </summary>
    /// <param name="buff">buff to apply</param>
    public void buffStat(Buff buff)
    {
        if (!isBuffed)
        {
            buffs.Add(buff);
            buffAmount += buff.ApplyBuffFormula(bonusAmount, 0);
            isBuffed = true;
        }
        else
        {
            buffs.Add(buff);
            buffAmount += buff.ApplyBuffFormula(bonusAmount, buffs.Count);
        }
    }
    /// <summary>
    /// Applies a debuff to the stat or stacks on existing ones (diminishing returns)
    /// </summary>
    /// <param name="buff"></param>
    public void buffStat(Debuff buff)
    {
        if (!isDebuffed)
        {
            debuffs.Add(buff);
            buffAmount -= buff.ApplyDebuffFormula(bonusAmount, 0);
            isDebuffed = true;
        }
        else
        {
            debuffs.Add(buff);
            buffAmount -= buff.ApplyDebuffFormula(bonusAmount, debuffs.Count);
        }
    }
    /// <summary>
    /// Clears all active buffs/debuffs
    /// </summary>
    public void ClearAllBuffs()
    {
        buffs.Clear();
        debuffs.Clear();
        isDebuffed = false;
        isBuffed = false;
    }
    /// <summary>
    /// Clears active buffs
    /// </summary>
    public void ClearBuffs()
    {
        buffs.Clear();
        isBuffed = false;
    }
    /// <summary>
    /// Clears active debuffs
    /// </summary>
    public void ClearDebuffs()
    {
        debuffs.Clear();
        isDebuffed = false;
    }


}
