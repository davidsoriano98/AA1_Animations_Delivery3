using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public LineRenderer _lRenderer;

    List<Vector3> points = new List<Vector3>();

    public bool Actived
    {
        get
        {
            return _lRenderer.enabled;
        }
        set
        {
            _lRenderer.enabled = value;
        }
    }

    public void Start()
    {
        Actived = false;
    }

    private static Vector3 GetProjectilePositionAtTime(Vector3 start, Vector3 startVelocity, float time, float m)
    {
        return start + startVelocity * time + (Vector3.left * m) * time * time * 0.5f;
    }


    public void SimulatePath(GameObject gameObject, Vector3 forceDirection, float mass, float drag, float _m, float maxTime, float timeStep)
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        float stepDrag = 1 - drag;
        Vector3 _velocity = forceDirection.normalized / mass;

        for (int i = 0; ; i++)
        {
            float time = timeStep * i;

            if (time > maxTime) break;
            stepDrag *= timeStep;
            _velocity *= timeStep;
            _velocity *= stepDrag;
            _m *= timeStep;

            Vector3 pos = GetProjectilePositionAtTime(gameObject.transform.position, _velocity, time, _m);
            points.Add(pos);
        }

        DrawTrajectory();
    }

    private void DrawTrajectory()
    {
        Color startColor = Color.magenta;
        Color endColor = Color.magenta;
        startColor.a = 1f;
        endColor.a = 1f;

        _lRenderer.transform.position = points[0];

        _lRenderer.startColor = startColor;
        _lRenderer.endColor = endColor;

        _lRenderer.positionCount = points.Count;

        for (int i = 0; i < points.Count; i++)
        {
            _lRenderer.SetPosition(i, points[i]);

        }
    }
}