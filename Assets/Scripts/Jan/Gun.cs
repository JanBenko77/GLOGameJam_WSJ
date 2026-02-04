using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Gun : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable xrgrab;
    [SerializeField] private InputActionReference triggerAction;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float maxDist = 3f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LineRenderer lineRenderer;
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        ray = new Ray(firePoint.transform.position, transform.forward);
    }

    private void Update()
    {

        if (xrgrab.isSelected)
        {
            lineRenderer.enabled = true;

            if (triggerAction.action.IsInProgress())
            {
                Shoot();
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    private void Shoot()
    {
        if (Physics.Raycast(ray, out hit, maxDist))
        {
            if (hit.transform.gameObject.CompareTag("Wafer"))
            {
                hit.transform.gameObject.GetComponent<Wafer>().HitRedDot();
                Debug.Log("Hit wafer");
            }
        }
    }
}

