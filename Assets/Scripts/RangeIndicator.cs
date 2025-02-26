using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    public GameObject indicatorPrefab;
    private Ground ground;

    private void Awake()
    {
        ground = FindObjectOfType<Ground>();
        Spawn(Vector3Int.zero, 5);
    }

    public void Spawn(Vector3Int position, int range)
    {
        for (int i = -range; i <= range; i++)
        {
            for (int j = -range; j <= range; j++)
            {
                var newPosition = new Vector3Int(position.x + i, position.y + j, 0);
                if (!ground.IsInRange(position, newPosition, range))
                {
                    continue;
                }

                var newIndicator = Instantiate(indicatorPrefab, transform);
                newIndicator.transform.position = newPosition;
            }
        }
    }
}
