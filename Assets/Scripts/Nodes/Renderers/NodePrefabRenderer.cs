using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePrefabRenderer : NodeRenderer
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;

    public override void Renderconnection(NodeConnection connection)
    {
        DrawPrefab(connection.flag ? floorPrefab : wallPrefab, connection.GetMidpoint());
    }

    public override void RenderNode(Node node)
    {
        DrawPrefab(floorPrefab, node.position);
    }

    private void DrawPrefab(GameObject prefab, Vector3 position)
    {
        var instance = GameObject.Instantiate(prefab, transform);
        instance.transform.position = position;
        instance.hideFlags = HideFlags.HideInHierarchy;
    }
}
