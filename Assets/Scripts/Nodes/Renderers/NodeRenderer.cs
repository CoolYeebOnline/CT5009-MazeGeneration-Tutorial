using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NodesMonoBehaviour))]
public abstract class NodeRenderer : MonoBehaviour
{
    public virtual void Start()
    {
        var nb = GetComponent<NodesMonoBehaviour>();
        Render(nb.nodes);
    }

    /// <summary>
    /// Renders all nodes and connections
    /// </summary>
    /// <param name="nodes"></param>
    public virtual void Render(Node[] nodes)
    {
        // Add a list of rendererd connections as not to render them twice 
        // (as connections link back)
        HashSet<NodeConnection> renderedConnections = new HashSet<NodeConnection>();

        foreach (Node n in nodes)
        {
            RenderNode(n);
            foreach (NodeConnection nc in n.connections)
            {
                if (renderedConnections.Contains(nc))
                    continue;

                RenderConnection(nc);
                renderedConnections.Add(nc);
            }
        }
    }


    /// <summary>
    /// Renders a single node
    /// </summary>
    /// <param name="node"></param>
    public abstract void RenderNode(Node node);

    /// <summary>
    /// Renders a single node connection
    /// </summary>
    /// <param name="connection"></param>
    public abstract void RenderConnection(NodeConnection connection);
}