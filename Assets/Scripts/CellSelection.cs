using UnityEngine;
using System.Linq;

public class CellSelection : MonoBehaviour
{

    [SerializeField]
    private Material materialCorrect, materialWrong;
    [SerializeField]
    private WaferGrid grid;
    [SerializeField]
    private LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(rayOrigin, out hit, Mathf.Infinity, layerMask))
            //if (Physics.Raycast(rayOriginTransform.position, rayOriginTransform.forward, out hit, Mathf.Infinity, layerMask))
            {
                if (grid.GetDrawPattern().gridPositions.Contains<Vector2Int>(hit.collider.GetComponent<GridCell>().GetPosition()))
                    hit.collider.GetComponent<Renderer>().material = materialCorrect;
                else 
                    hit.collider.GetComponent<Renderer>().material = materialWrong;
            }
        }
    }
}
