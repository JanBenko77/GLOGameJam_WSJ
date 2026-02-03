using UnityEngine;

public class WaferGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject gridCellPrefab;
    private GridCell[,] gridCells;
    private int spacing = 3, gridSize = 3;
    [SerializeField]
    private Transform spawnPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gridCells = new GridCell[gridSize,gridSize];
        for (int i = 0; i < gridSize; i++) {
            for (int j = 0; j < gridSize; j++) {
                spawnPosition.Translate(new Vector3(spacing, 0, 0));
                GameObject newGirdCell = Instantiate(gridCellPrefab, spawnPosition.position, Quaternion.identity, transform);
                newGirdCell.AddComponent<GridCell>().SetPosition(j, i);
                gridCells[i,j] = newGirdCell.GetComponent<GridCell>();
            }
            spawnPosition.Translate(new Vector3(-gridSize * spacing, 0, spacing));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GridCell GetGridCell(int gridX, int gridY)
    {
        return gridCells[gridX, gridY];
    }
}
