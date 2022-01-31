using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector3 position;

    public bool visited;

    public List<NodeConnection> connections = new List<NodeConnection>();

    public bool HasConnection(Node toCheck)
    {
        if (toCheck == this)
            return false;

        foreach (NodeConnection nc in connections)
        {
            if (nc.a == toCheck || nc.b == toCheck)
                return true;
        }

        return false;
    }

    public NodeConnection MakeConnection(Node other, float cost = 0)
    {
        var connection = new NodeConnection()
        {
            a = this,
            b = other,
            cost = cost
        };
        connections.Add(connection);
        other.connections.Add(connection);
        return connection;
    }

    public bool FlagConnection(Node other)
    {
        if (other == this)
            return false;

        foreach (NodeConnection nc in connections)
        {
            if (GetNeighbourFromConnection(nc) == other)
            {
                nc.flag = true;
                return true;
            }
        }
        return false;
    }

    public Node[] GetNeighbours()
    {
        int size = connections.Count;
        Node[] neighbours = new Node[size];
        for (int i = 0; i < size; i++)
        {
            neighbours[i] = GetNeighbourFromConnection(connections[i]);
        }
        return neighbours;
    }

    private NodeConnection[] GetNodeConnections(bool isFlagged)
    {
        List<NodeConnection> selected = new List<NodeConnection>();
        foreach (NodeConnection nc in connections)
        {
            if (nc.flag == isFlagged)
                selected.Add(nc);
        }
        return selected.ToArray();
    }

    public Node[] GetNeighboursFromFlaggedConnections()
    {
        return GetNeighboursFromConnections(GetNodeConnections(true));
    }

    public Node[] GetNeighboursFromUnflaggedConnections()
    {
        return GetNeighboursFromConnections(GetNodeConnections(false));
    }

    private Node[] GetNeighboursFromConnections(NodeConnection[] connections)
    {
        int length = connections.Length;
        Node[] nodes = new Node[length];
        for (int i = 0; i < length; i++)
        {
            nodes[i] = GetNeighbourFromConnection(connections[i]);
        }
        return nodes;
    }

    public Node[] GetVisitedNeighbours()
    {
        return GetNeighbours(true);
    }

    public Node[] GetUnvisitedNeighbours()
    {
        return GetNeighbours(false);
    }

    private Node[] GetNeighbours(bool visited)
    {
        List<Node> neighbours = new List<Node>();
        foreach (NodeConnection nc in connections)
        {
            var node = GetNeighbourFromConnection(nc);
            if (node.visited == visited)
                neighbours.Add(node);
        }
        return neighbours.ToArray();
    }

    public Node GetNeighbourFromConnection(NodeConnection nc)
    {
        return nc.a == this ? nc.b : nc.a;
    }

    public NodeConnection GetConnectionFromNeighbour(Node node)
    {
        if (node == this)
            return null;

        foreach (NodeConnection nc in connections)
        {
            if (nc.a == node || nc.b == node)
                return nc;
        }

        return null;
    }
}