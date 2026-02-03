using UnityEngine;

public class SprayPaint : MonoBehaviour
{
    [SerializeField]
    private GameObject sprayPrefab;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Transform rayOriginTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(rayOrigin, out hit, Mathf.Infinity, layerMask))
            //if (Physics.Raycast(rayOriginTransform.position, rayOriginTransform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Instantiate(sprayPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
