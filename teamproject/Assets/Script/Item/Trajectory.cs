using UnityEngine;
using System.Collections.Generic;

public class Trajectory : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private int resolution = 50;
    public float simulationTime = 2.0f;
    public float timeStep = 0.05f;
    public LayerMask hitMask;
    public void DrawTrajectory(Vector3 startPos, Vector3 velocity)
    {
        List<Vector3> points = new List<Vector3>();
        Vector3 currentPos = startPos;
        Vector3 currentVelocity = velocity;

        for (int i = 0; i < resolution; i++)
        {
            points.Add(currentPos);

            Vector3 nextPos = currentPos + currentVelocity * timeStep + 0.5f * Physics.gravity * timeStep * timeStep;
            currentVelocity += Physics.gravity * timeStep;

            // “r’†‚Å•Ç‚É“–‚½‚Á‚½‚ç‚»‚±‚Å‘Å‚¿Ø‚è
            if (Physics.Linecast(currentPos, nextPos, out RaycastHit hit, hitMask))
            {
                points.Add(hit.point);
                break;
            }

            currentPos = nextPos;
        }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    public void ClearTrajectory()
    {
        lineRenderer.positionCount = 0;
    }
}