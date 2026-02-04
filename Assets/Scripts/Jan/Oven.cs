using UnityEngine;

public class Oven : MonoBehaviour
{
    [SerializeField] private Transform cookingPlace;
    [SerializeField] private Wafer wafer;
    private float timer = 0f;
    private bool cooking = false;

    public void StartCooking()
    {
        cooking = true;
        wafer.transform.position = cookingPlace.position;
        wafer.transform.rotation = cookingPlace.rotation;
    }

    private void Update()
    {
        if (cooking)
        {
            timer += Time.deltaTime;

            if (timer >= 30f)
            {
                Debug.Log("Shit is done");
                cooking = false;
                timer = 0f;
                wafer.SwitchKinematic();
            }
        }
    }
}
