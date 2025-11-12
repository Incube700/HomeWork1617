using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    [SerializeField] private List<Transform> _points = new List<Transform>();

    public int Count
    {
        get { return _points != null ? _points.Count : 0; }
    }

    public Vector3 GetPoint(int index)
    {
        if (_points == null || _points.Count == 0)
        {
            return transform.position;
        }

        if (index < 0) index = 0;
        if (index >= _points.Count) index = _points.Count - 1;

        return _points[index].position;
    }

    private void OnDrawGizmos()
    {
        if (_points == null || _points.Count < 2)
        {
            return;
        }

        Gizmos.color = Color.cyan;
        for (int i = 0; i < _points.Count; i++)
        {
            Vector3 a = _points[i].position;
            Vector3 b = _points[(i + 1) % _points.Count].position;
            Gizmos.DrawLine(a, b);
            Gizmos.DrawWireSphere(a, 0.15f);
        }
    }
}