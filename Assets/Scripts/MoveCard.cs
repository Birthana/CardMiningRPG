using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Card/Move")]
public class MoveCard : CardInfo, IActionCard
{
    public bool CanPlay(Mouse mouse, Ground ground)
    {
        var currentPosition = ground.GetClosetTilePosition(GetCharacter().transform.position);
        var positionToMove = ground.GetClosetTilePosition(mouse.GetMousePosition());
        return ground.IsInRange(currentPosition, positionToMove, GetCharacter().MOVE_RANGE);
    }

    public void Action(Mouse mouse, Ground ground)
    {
        MoveToMousePosition(mouse, ground);
    }

    private void MoveToMousePosition(Mouse mouse, Ground ground)
    {
        var positionToMove = ground.GetClosetTilePosition(mouse.GetMousePosition());
        GetCharacter().Move(positionToMove);
    }
}
