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
        lineRenderer.positionCount = 5;
        lineRenderer.SetPosition(0, grid.GetGridCell(0, 0).transform.position);
        lineRenderer.SetPosition(1, grid.GetGridCell(0, 2).transform.position);
        lineRenderer.SetPosition(2, grid.GetGridCell(2, 2).transform.position);
        lineRenderer.SetPosition(3, grid.GetGridCell(2, 1).transform.position);
        lineRenderer.SetPosition(4, grid.GetGridCell(1, 1).transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
