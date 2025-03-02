public interface IActionCard
{
    public abstract bool CanPlay(Mouse mouse, Ground ground, RangeIndicator rangeIndicator);
    public abstract void Action(Mouse mouse, Ground ground);
}
