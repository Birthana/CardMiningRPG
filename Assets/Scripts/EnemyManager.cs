using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<Enemy> enemies;
    private Ground ground;

    private void Start()
    {
        enemies = new List<Enemy>(FindObjectsOfType<Enemy>());
        ground = FindObjectOfType<Ground>();
    }

    public void Move()
    {
        foreach(var enemy in enemies)
        {
            var positionToMove = GetPositionToMove(enemy.transform.position);
            if (positionToMove == enemy.transform.position)
            {
                continue;
            }

            enemy.Move(positionToMove);
        }
    }

    public void Attack()
    {
        foreach (var enemy in enemies)
        {
            var player = FindObjectOfType<Player>();
            enemy.Attack(player);
        }
    }

    private Vector3 GetPositionToMove(Vector3 currentPosition)
    {
        var result = currentPosition;
        var directions = new List<Vector3>() { Vector3.up, Vector3.down, Vector3.left, Vector3.right };
        bool moved = false;
        while(directions.Count > 0 && !moved)
        {
            var rngDirection = directions[Random.Range(0, directions.Count)];
            directions.Remove(rngDirection);
            var positionToMove = currentPosition + rngDirection;
            if (Raycast.HitsContain<IDamageable>(positionToMove) ||
                Raycast.HitsContain<IMineable>(positionToMove))
            {
                continue;
            }

            Debug.Log($"Move: {rngDirection}");
            result = ground.GetClosetTilePosition(currentPosition + rngDirection);
            moved = true;
        }

        return result;
    }
}
