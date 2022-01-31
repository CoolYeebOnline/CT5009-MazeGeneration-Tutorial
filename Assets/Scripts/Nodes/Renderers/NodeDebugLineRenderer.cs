using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDebugLineRenderer : NodeRenderer
{
    override public void RenderNode(Node n)
    {
        // Do nothing
    }

    override public void RenderConnection(NodeConnection nc)
    {
        Debug.DrawLine(nc.a.position, nc.b.position, nc.flag ? Color.red : Color.black, 1000000);
    }
}