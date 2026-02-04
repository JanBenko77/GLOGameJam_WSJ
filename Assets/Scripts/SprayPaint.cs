using UnityEngine;
using System.Collections.Generic;

public class SprayPaint : MonoBehaviour
{
    [SerializeField]
    private GameObject sprayPrefab;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Transform rayOriginTransform;
    private LineRenderer lineRenderer;
    [SerializeField]
    private LineRenderer previewLine;
    private int counter;
    private Vector3 previousHit = new Vector3(100, 100, 100);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(rayOrigin, out hit, Mathf.Infinity, layerMask) && Time.frameCount % 5 == 0 && Vector3.Distance(hit.point, previousHit) > 0.3f)
            //if (Physics.Raycast(rayOriginTransform.position, rayOriginTransform.forward, out hit, Mathf.Infinity, layerMask))
            {
                previousHit = hit.point;
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(counter, hit.point);
                counter++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
            ChangeToSelection();
    }

    private void ChangeToSelection()
    {
        GetComponent<CellSelection>().enabled = true;
        GetComponent<LineRenderer>().enabled = false;
        previewLine.enabled = false;
        enabled = false;
        GameManager.instance.SetMinigameDone();
    }

    public float Compare(LineRenderer a, LineRenderer b, int sampleCount = 100)
{
    if (a.positionCount < 2 || b.positionCount < 2)
        return 0f;

    var aPoints = GetPositions(a);
    var bPoints = GetPositions(b);

    var aResampled = Resample(aPoints, sampleCount);
    var bResampled = Resample(bPoints, sampleCount);

    for (int i = 0; i < sampleCount; i++)
    {
        aResampled[i] = new Vector3(aResampled[i].x, 0f, aResampled[i].z);
        bResampled[i] = new Vector3(bResampled[i].x, 0f, bResampled[i].z);
    }

    Normalize(aResampled);
    Normalize(bResampled);

    float totalDistance = 0f;
    for (int i = 0; i < sampleCount; i++)
    {
        totalDistance += Vector3.Distance(aResampled[i], bResampled[i]);
    }

    float avgDistance = totalDistance / sampleCount;

    float similarity = Mathf.Clamp01(1f - (avgDistance / 0.2f));
    return similarity * 100f;
}


    private List<Vector3> GetPositions(LineRenderer lr)
    {
        var points = new Vector3[lr.positionCount];
        lr.GetPositions(points);
        return new List<Vector3>(points);
    }

    private List<Vector3> Resample(List<Vector3> points, int targetCount)
    {
        float totalLength = 0f;
        for (int i = 1; i < points.Count; i++)
            totalLength += Vector3.Distance(points[i - 1], points[i]);

        float segmentLength = totalLength / (targetCount - 1);
        float distanceSoFar = 0f;

        List<Vector3> result = new List<Vector3> { points[0] };
        int currentIndex = 1;

        while (result.Count < targetCount - 1)
        {
            float dist = Vector3.Distance(points[currentIndex - 1], points[currentIndex]);

            if (distanceSoFar + dist >= segmentLength)
            {
                float t = (segmentLength - distanceSoFar) / dist;
                Vector3 newPoint = Vector3.Lerp(points[currentIndex - 1], points[currentIndex], t);
                result.Add(newPoint);
                points.Insert(currentIndex, newPoint);
                distanceSoFar = 0f;
            }
            else
            {
                distanceSoFar += dist;
                currentIndex++;
                if (currentIndex >= points.Count)
                    break;
            }
        }

        result.Add(points[points.Count - 1]);
        return result;
    }

    private void Normalize(List<Vector3> points)
    {
        Vector3 center = Vector3.zero;
        foreach (var p in points) center += p;
        center /= points.Count;

        for (int i = 0; i < points.Count; i++)
            points[i] -= center;

        float maxDist = 0f;
        foreach (var p in points)
            maxDist = Mathf.Max(maxDist, p.magnitude);

        if (maxDist > 0f)
        {
            for (int i = 0; i < points.Count; i++)
                points[i] /= maxDist;
        }
    }
}
