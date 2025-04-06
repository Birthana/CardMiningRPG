public interface IActionCard
{
    public abstract int GetEnergy();
    public abstract bool CanPlay(Ground ground, RangeIndicator rangeIndicator);
    public abstract void Action(Ground ground);
}
