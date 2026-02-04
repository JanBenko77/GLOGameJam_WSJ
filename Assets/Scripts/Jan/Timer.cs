using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timePassed = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
    }
}
