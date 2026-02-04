using System.Collections.Generic;
using UnityEngine;

public class Wafer : MonoBehaviour
{
    private List<MeshRenderer> renderers;
    [SerializeField] private Material mat2;
    [SerializeField] private Material mat3;
    private Rigidbody rb;

    public bool isDoneCooking = false;


    private void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            MeshRenderer rend = child.gameObject.GetComponent<MeshRenderer>();
            renderers.Add(rend);
        }

        rb = GetComponent<Rigidbody>();
    }

    public void SprayWafer()
    {
        
    }

    public void ClearWafer()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Oven"))
        {
            if (!isDoneCooking)
            {
                collision.gameObject.GetComponent<Oven>().StartCooking();
                rb.isKinematic = true;
            }
        }
    }

    public void SwitchKinematic()
    {
        rb.isKinematic = !rb.isKinematic;
        isDoneCooking = true;
    }

    private void StartGunMinigame()
    {

    }

    public void HitRedDot()
    {

    }
}