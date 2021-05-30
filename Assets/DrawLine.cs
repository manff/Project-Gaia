using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    // private float counter;
    //private float dist;

    public Transform origin;
    public Transform destination;

    public float lineDrawSpeed = 6f;

    public Vector3 start;
    public Vector3 end;

    public float x = 0;
    public float z = 0;
    public float d = 0;
    public float distX;
    public float distZ;
    public float distance;
    public int stepCount;
    public float curveStrength;
    public float yOffset = 0.1f;

    public List<Vector3> points;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();

    }
    private void Update() {

        start = new Vector3(origin.transform.position.x, origin.transform.position.y, origin.transform.position.z);
        end = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
        distance = Vector3.Distance(end, start);

        x = start.x;
        z = start.z;

        distX = end.x - start.x;
        distZ = end.z - start.z;

        stepCount = 50;

        points = new List<Vector3>();

        lineRenderer.positionCount = stepCount + 1;

        lineRenderer.SetPosition(0, start);

        for (int i = 0; i <= stepCount; i++)
        {
            if (i != 0)
            {
                x = x + distX / stepCount;
                z = z + distZ / stepCount;
                d = Mathf.Sqrt(Mathf.Pow(x - start.x, 2) + Mathf.Pow(z - start.z, 2));
            }

            points.Add(new Vector3(x, -curveStrength * (d - 0) * (d - distance) + yOffset, z));

            lineRenderer.SetPosition(i, points[i]);
        }
    }
}
