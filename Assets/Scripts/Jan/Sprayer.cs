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
        //spray water or something
        //raycast spray to surface of wafer
        //paint surface of wafer

    }
}
