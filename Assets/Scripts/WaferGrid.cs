using UnityEngine;

public class WaferGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject gridCellPrefab;
    private GridCell[,] gridCells;
    private int gridSize = 3;
    private float spacing = 2f;
    [SerializeField]
    private Transform spawnPosition;
    [SerializeField]
    private DrawPatternSODefinition[] drawPatterns;
    private DrawPatternSODefinition currentDrawPattern;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spacing *= transform.localScale.x;
        CreateGrid(gridSize, spacing);
    }

    private void CreateGrid(int gridSize, float spacing)
    {
        currentDrawPattern = drawPatterns[Random.Range(0, drawPatterns.Length)];
        gridCells = new GridCell[gridSize,gridSize];
        for (int i = 0; i < gridSize; i++) {
            for (int j = 0; j < gridSize; j++) {
                spawnPosition.Translate(new Vector3(spacing, 0, 0));
                GameObject newGirdCell = Instantiate(gridCellPrefab, spawnPosition.position, Quaternion.identity, transform);
                newGirdCell.AddComponent<GridCell>().SetPosition(i, j);
                gridCells[i,j] = newGirdCell.GetComponent<GridCell>();
            }
            spawnPosition.Translate(new Vector3(-gridSize * spacing, 0, spacing));
        }
    }

    public GridCell GetGridCell(int gridX, int gridY)
    {
        return gridCells[gridX, gridY];
    }

    public DrawPatternSODefinition GetDrawPattern()
    {
        return currentDrawPattern;
        //return drawPatterns[0];
    }
}
