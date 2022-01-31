using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class NodeGrid : NodesMonoBehaviour
{
    public int nodesInWidth = 10;
    public int nodesInHeight = 10;
    public int nodesSpacing = 2;
    public bool useZPositionAsY = true;

    void OnEnable()
    {
        nodes = CreateNodeGrid(nodesInWidth, nodesInHeight, nodesSpacing, useZPositionAsY);

        var solver = GetComponent<INodeSolver>();
        if (solver != null)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            solver.Solve(nodes);

            sw.Stop();
            UnityEngine.Debug.Log("Took " + sw.ElapsedMilliseconds + "ms to solve with " + solver.GetType().Name);
        }
    }

    public static Node[] CreateNodeGrid(int width, int height, float spacing, bool useZPositionAsY = true)
    {
        int i = 0;
        var nodes = new Node[width * height];
        var nodesGrid = new Node[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var node = new Node()
                {
                    position = new Vector3(x * spacing, useZPositionAsY ? 0 : y * spacing, useZPositionAsY ? y * spacing : 0)
                };

                if (x > 0)
                    node.MakeConnection(nodesGrid[x - 1, y]);
                if (y > 0)
                    node.MakeConnection(nodesGrid[x, y - 1]);

                nodesGrid[x, y] = node;
                nodes[i] = node;

                i++;
            }
        }

        return nodes;
    }
}
