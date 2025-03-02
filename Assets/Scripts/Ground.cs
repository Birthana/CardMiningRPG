using UnityEngine;
using UnityEngine.Tilemaps;

public class Ground : MonoBehaviour
{
    public Tilemap tilemap;

    public Vector3 GetClosetTilePosition(Vector3 position)
    {
        var closestTile = tilemap.WorldToCell(position);
        return tilemap.transform.position + tilemap.CellToWorld(closestTile);
    }

    public bool IsInRange(Vector3 currentPosition, Vector3 movePosition, int moveRange)
    {
        var currentTile = tilemap.WorldToCell(currentPosition);
        var moveTile = tilemap.WorldToCell(movePosition);
        var distance = currentTile - moveTile;
        return Mathf.Abs(distance.x) + Mathf.Abs(distance.y) <= moveRange;
    }
}
