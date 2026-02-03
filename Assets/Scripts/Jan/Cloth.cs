using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Cloth : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable xrgrab;
    private bool isPickedUp = false;

    private void Update()
    {
        if (xrgrab.isSelected)
        {
            isPickedUp = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (isPickedUp)
        {
            //can wipe or whatever
        }
    }
}
