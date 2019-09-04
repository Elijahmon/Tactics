
public class CharacterResource : CharacterStat {

    protected int currentResource;
    protected int maxResource;

    public CharacterResource(int baseStat, STATE_TYPE statType) : base(baseStat, statType)
    {
        currentResource = baseAmount + bonusAmount;
        maxResource = baseAmount + bonusAmount;
    }


    /// <summary>
    /// Refills a given amount of the resource (will not overfill)
    /// </summary>
    /// <param name="amount">amount to refill</param>
    /// <returns>returns true if resource is maxed out</returns>
    public void RefillResource(int amount)
    {
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
    public override void ModifyStat(int mod)
    {
    }

    /// <summary>
    /// Uses a given amount of a resource
    /// </summary>
    /// <param name="amount">amount of resource expended</param>
    public void UseResource(int amount)
    {
    }

    /// <summary>
    /// Gets the current amount of the resource
    /// </summary>
    /// <returns>amount of resource</returns>
    public int GetCurrent()
    {
        return currentResource;
    }

    /// <summary>
    /// Gets the max amount of the resource
    /// </summary>
    /// <returns>max amount of resource</returns>
    public int GetMax()
    {
        return maxResource;
    }
}
