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
    public Wafer wafer;
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        ray = new Ray(firePoint.transform.position, firePoint.forward);
    }

    private void Update()
    {

        if (xrgrab.isSelected)
        {
            Gizmos.DrawLine(ray.origin, ray.direction);

            if (triggerAction.action.IsInProgress())
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        if (Physics.Raycast(ray, out hit, maxDist))
        {
            if (hit.transform.gameObject.CompareTag("Wafer"))
            {
                wafer.HitRedDot();
                Debug.Log("Hit wafer");
            }
        }
    }
}

