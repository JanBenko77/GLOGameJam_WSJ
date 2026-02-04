using UnityEngine;

public class Wafer : MonoBehaviour
{
    private MeshRenderer m_Renderer;
    [SerializeField] private Material mat2;
    [SerializeField] private Material mat3;
    private Rigidbody rb;

    public bool isDoneCooking = false;


    private void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    public void SprayWafer()
    {
        m_Renderer.material = mat2;
    }

    public void ClearWafer()
    {
        m_Renderer.material = mat3;
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