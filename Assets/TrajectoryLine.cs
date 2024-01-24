using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [SerializeField] private int segmentCount = 58;
    [SerializeField] private float curveLenght = 3.5f;

    private Vector2[] segments;
    private LineRenderer lineRenderer;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    private const float TIME_CURVE_ADDITION = 0.5f;

    private void Start()
    {
        segments = new Vector2[segmentCount];
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segmentCount;
    }

    private void Update()
    {
        Vector2 startPos = startPoint.position;
        segments[0] = startPos;
        lineRenderer.SetPosition(0, startPos);

        Vector2 startVelocity = transform.right * 2;

        for (int i = 1; i < segmentCount; i++)
        {
            float timeOffset = (i * Time.deltaTime * curveLenght);

            Vector2 gravityOffset = TIME_CURVE_ADDITION * Physics2D.gravity * Mathf.Pow(timeOffset, 2);

            segments[i] = segments[0] + startVelocity * timeOffset + gravityOffset;
            lineRenderer.SetPosition(i, segments[1]);

        }
    }
}
