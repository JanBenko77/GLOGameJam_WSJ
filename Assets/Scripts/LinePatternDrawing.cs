using UnityEngine;

public class LinePatternDrawing : MonoBehaviour
{
    [SerializeField]
    private WaferGrid grid;
    private LineRenderer lineRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        Vector2Int[] positions = grid.GetDrawPattern().gridPositions;
        lineRenderer.positionCount = positions.Length;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            GridCell gridCell = grid.GetGridCell(positions[i].x, positions[i].y);
            lineRenderer.SetPosition(i, gridCell.transform.position);
        }
    }
}
