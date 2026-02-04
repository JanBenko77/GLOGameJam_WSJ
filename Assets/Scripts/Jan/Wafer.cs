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
        renderers = new();

        foreach (Transform child in gameObject.transform)
        {
            MeshRenderer rend = child.gameObject.GetComponent<MeshRenderer>();
            renderers.Add(rend);
        }

        rb = GetComponent<Rigidbody>();
    }

    public void SprayWafer()
    {
        foreach (MeshRenderer rend in renderers)
        {
            List<Material> newList = new List<Material>();
            newList.Add(mat2);
            rend.SetMaterials(newList);
        }
    }

    public void ClearWafer()
    {
        foreach (MeshRenderer rend in renderers)
        {
            List<Material> newList = new List<Material>();
            newList.Add(mat3);
            rend.SetMaterials(newList);
        }
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