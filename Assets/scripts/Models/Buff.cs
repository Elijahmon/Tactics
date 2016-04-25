
namespace Buff_Debuff
{
    public abstract class Buff
    {
        protected string name;

        public abstract int ApplyBuffFormula(int stat, int activeBuffs);
    }
    public abstract class Debuff
    {
        protected string name;

        public abstract int ApplyDebuffFormula(int stat, int activeDebuffs);
    }
}
