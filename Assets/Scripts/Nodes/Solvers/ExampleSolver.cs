using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleSolver : MonoBehaviour, INodeSolver
{
    public void Solve(Node[] nodes)
    {
        Node startNode = nodes[UnityEngine.Random.Range(0, nodes.Length)];
        VisitAndRandomFlag(startNode, 5);
    }
    
    private void VisitAndRandomFlag(Node node, int count)
    {
        node.visited = true;
        var neighbours = node.GetUnvisitedNeighbours();

        if (neighbours.Length == 0)
            return;

        var neighbour = neighbours[UnityEngine.Random.Range(0, neighbours.Length)];
        node.FlagConnection(neighbour);

        VisitAndRandomFlag(neighbour, count - 1);
    }
}
