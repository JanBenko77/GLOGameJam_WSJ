using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Sprayer : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable xrgrab;
    [SerializeField] private InputActionReference triggerAction;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float maxDist = 3f;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {

        if (xrgrab.isSelected)
        {
            if (triggerAction.action.IsInProgress())
            {
                Spray();
            }
        }
    }

    private void Spray()
    {
        Ray ray = new Ray(firePoint.transform.position, firePoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDist, layerMask))
        {
            if (hit.transform.gameObject.CompareTag("Wafer"))
            {
                Debug.Log("Hit wafer");
            }
        } 
    }
}
