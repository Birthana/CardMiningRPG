using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Card/Move")]
public class MoveCard : CardInfo, IActionCard
{
    public void Action(Mouse mouse, Ground ground)
    {
        MoveToMousePosition(mouse, ground);
    }

    private void MoveToMousePosition(Mouse mouse, Ground ground)
    {
        var currentPosition = ground.GetClosetTilePosition(GetCharacter().transform.position);
        var positionToMove = ground.GetClosetTilePosition(mouse.GetMousePosition());
        if (!IsInRange(currentPosition, positionToMove, GetCharacter().MOVE_RANGE))
        {
            return;
        }

        GetCharacter().Move(positionToMove);
    }
}
