using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector2 size;
    public GameObject prefab;
    public int count;
    private Ground ground;

    private void Awake()
    {
        ground = FindObjectOfType<Ground>();
        Spawn();
    }

    public void Spawn()
    {
        var centerTilePosition = ground.GetClosetTilePosition(transform.position);
        var rngPositions = GetRngPositions(centerTilePosition);
        foreach (var rngPosition in rngPositions)
        {
            SpawnAt(centerTilePosition + rngPosition);
        }
    }

    private List<Vector3> GetRngPositions(Vector3 offset)
    {
        var rngPositions = new List<Vector3>();
        for (int i = 0; i < count; i++)
        {
            Vector3 rngPosition;
            do
            {
                rngPosition = GetRngPosition();
            } while (rngPositions.Contains(rngPosition) || Raycast.GetHitsAt(offset + rngPosition).Length > 0);

            rngPositions.Add(rngPosition);
        }

        return rngPositions;
    }

    private Vector3 GetRngPosition()
    {

        int x = (int)(size.x / 2);
        int y = (int)(size.y / 2);
        return new Vector3(Random.Range(-x, x), Random.Range(-y, y), 0);
    }

    private void SpawnAt(Vector3 position)
    {
        var enemy = Instantiate(prefab, transform);
        enemy.transform.position = position;
    }

    private void OnDrawGizmos()
    {
        if (size.x == 0 || size.y == 0)
        {
            return;
        }

        Gizmos.DrawWireCube(transform.position, size);
    }
}
