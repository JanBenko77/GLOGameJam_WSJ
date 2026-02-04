using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Cloth : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable xrgrab;
    private bool isPickedUp = false;
    public Wafer wafer;

    private void Update()
    {
        if (xrgrab.isSelected)
        {
            isPickedUp = true;
        }
        else
        {
            isPickedUp = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (isPickedUp)
        {
            if (collision.gameObject.CompareTag("Wafer"))
            {
                wafer.ClearWafer();
                Debug.Log("Wiping the wafer");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isPickedUp)
        {
            if (other.gameObject.CompareTag("Wafer"))
            {
                wafer.ClearWafer();
                Debug.Log("Wiping the wafer");
            }
        }
    }
}
