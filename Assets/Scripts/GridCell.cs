using UnityEngine;

public class GridCell : MonoBehaviour
{
    private Vector2Int gridPosition;

    public void SetPosition(int targetX, int targetY)
    {
        gridPosition = new Vector2Int(targetX, targetY);
        print(gridPosition);
    }

    public Vector2Int GetPosition()
    {
        return gridPosition;
    }
}
