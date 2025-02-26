public interface IActionCard
{
    public abstract bool CanPlay(Mouse mouse, Ground ground);
    public abstract void Action(Mouse mouse, Ground ground);
}
