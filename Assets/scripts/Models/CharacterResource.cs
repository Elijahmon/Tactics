
public class CharacterResource : CharacterStat {

    protected int currentResource;
    protected int maxResource;

    public CharacterResource(int baseStat, STATE_TYPE statType) : base(baseStat, statType)
    {
        currentResource = baseAmount + bonusAmount;
    }


    /// <summary>
    /// Refills a given amount of the resource (will not overfill)
    /// </summary>
    /// <param name="amount">amount to refill</param>
    /// <returns>returns true if resource is maxed out</returns>
    public bool RefillResource(int amount)
    {
       if(amount + currentResource <= maxResource)
        {
            currentResource = maxResource;
            return true;
        }
        else
        {
            currentResource += amount;
            return false;
        }
    }
    /// <summary>
    /// Checks if there is enough for a given cost
    /// </summary>
    /// <param name="cost">cost of the task</param>
    /// <returns>true if there is enough</returns>
    public bool HasEnoughResource(int cost)
    {
        if (cost <= currentResource)
            return true;
        else
            return false;

    }
    /// <summary>
    /// changes the bonus amount for the resource and updates its max
    /// </summary>
    /// <param name="mod">amount to modify the stat by</param>
    /// <returns>returns 0 for lowered stat and 1 for increased stat</returns>
    public override int modifyStat(int mod)
    {
        int outCode = base.modifyStat(mod);
        maxResource = baseAmount + bonusAmount + buffAmount;
        return outCode;
    }
    /// <summary>
    /// Expends a given amount of a resource
    /// </summary>
    /// <param name="amount">amount of resource expended</param>
    /// <returns>false if resource is now 0</returns>
    public bool ExpendResource(int amount)
    {
        if (amount < 0)
            return true;
        if(currentResource - amount <= 0)
        {
            currentResource = 0;
            return false;
        }
        else
        {
            currentResource -= amount;
            return true;
        }
    }
}
