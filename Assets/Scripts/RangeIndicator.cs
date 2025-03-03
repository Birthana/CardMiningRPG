using System.Collections.Generic;
using UnityEngine;

public struct RangePosition
{
    public Vector3 position;
    public int range;

    public RangePosition(Vector3 position, int range)
    {
        this.position = position;
        this.range = range;
    }
}

public class RangeIndicator : MonoBehaviour
{
    public GameObject indicatorPrefab;
    private List<GameObject> indicators = new List<GameObject>();

    public void SpawnWithCollision(Vector3 position, int range)
    {
        var positionsToCheck = new List<RangePosition>();
        positionsToCheck.Add(new RangePosition(position, 0));
        while(positionsToCheck.Count > 0)
        {
            var positionToCheck = positionsToCheck[0];
            positionsToCheck.RemoveAt(0);

            if (positionToCheck.range > range)
            {
                continue;
            }

            var adjacentPositions = GetAdjacentPositions(positionToCheck.position);
            foreach(var adjacentPosition in adjacentPositions)
            {
                if (Raycast.HitsContain<IDamageable>(adjacentPosition) ||
                    Raycast.HitsContain<IMineable>(adjacentPosition))
                {
                    continue;
                }

                positionsToCheck.Add(new RangePosition(adjacentPosition, positionToCheck.range + 1));
            }

            ShowAt(positionToCheck.position);
        }
    }

    public void Spawn(Vector3 position, int range)
    {
        var positionsToCheck = new List<RangePosition>();
        positionsToCheck.Add(new RangePosition(position, 0));
        while (positionsToCheck.Count > 0)
        {
            var positionToCheck = positionsToCheck[0];
            positionsToCheck.RemoveAt(0);

            if (positionToCheck.range > range)
            {
                continue;
            }

            var adjacentPositions = GetAdjacentPositions(positionToCheck.position);
            foreach (var adjacentPosition in adjacentPositions)
            {
                positionsToCheck.Add(new RangePosition(adjacentPosition, positionToCheck.range + 1));
            }

            ShowAt(positionToCheck.position);
        }
    }

    private List<Vector3> GetAdjacentPositions(Vector3 position)
    {
        var positions = new List<Vector3>();
        positions.Add(position + Vector3.up);
        positions.Add(position + Vector3.down);
        positions.Add(position + Vector3.left);
        positions.Add(position + Vector3.right);
        return positions;
    }

    public bool IsInRange(Vector3 position)
    {
        if (indicators.Count == 0)
        {
            return false;
        }

        foreach (var indicator in indicators)
        {
            if (!indicator.activeInHierarchy)
            {
                continue;
            }

            if (indicator.transform.position == position)
            {
                return true;
            }
        }

        return false;
    }

    public void ShowAt(Vector3 position)
    {
        if (Contains(position))
        {
            var indicator = GetIndicatorAt(position);
            indicator.SetActive(true);
            return;
        }

        CreateAt(position);
    }

    public void Despawn()
    {
        foreach (var indicator in indicators)
        {
            indicator.SetActive(false);
        }
    }

    private void CreateAt(Vector3 position)
    {
        var newIndicator = Instantiate(indicatorPrefab, transform);
        newIndicator.transform.position = position;
        indicators.Add(newIndicator);
    }

    private bool Contains(Vector3 position)
    {
        return GetIndicatorAt(position) != null;
    }

    private GameObject GetIndicatorAt(Vector3 position)
    {
        if (indicators.Count == 0)
        {
            return null;
        }

        foreach (var indicator in indicators)
        {
            if (indicator.transform.position == position)
            {
                return indicator;
            }
        }

        return null;
    }
}
