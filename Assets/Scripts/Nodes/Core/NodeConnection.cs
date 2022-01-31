using UnityEngine;

public class NodeConnection
{
    public bool flag;
    public float cost = 0;
    public Node a;
    public Node b;

    public Vector3 GetMidpoint()
    {
        return a.position + (b.position - a.position) * 0.5f;
    }
}