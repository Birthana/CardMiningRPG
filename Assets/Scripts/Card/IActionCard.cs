public interface IActionCard
{
    public abstract int GetEnergy();
    public abstract bool CanPlay(Mouse mouse, Ground ground, RangeIndicator rangeIndicator);
    public abstract void Action(Mouse mouse, Ground ground);
}
