using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Node
{
    public readonly Point point;
    public readonly List<Point> incoming = new List<Point>();
    public readonly List<Point> outgoing = new List<Point>();
    [JsonConverter(typeof(StringEnumConverter))]
    public readonly NodeType nodeType;
    public readonly string blueprintName;
    public Vector2 position;

    public Node(NodeType nodeType, string blueprintName, Point point)
    {
        this.nodeType = nodeType;
        this.blueprintName = blueprintName;
        this.point = point;
    }

    public void AddIncoming(Point point) 
    {
        if (incoming.Any(e => e.Equals(point))) return;
        incoming.Add(point);
    }

    public void RemoveIncoming(Point point)
    {
        incoming.RemoveAll(e => e.Equals(point));
    }

    public void AddOutgoing(Point point)
    {
        if (outgoing.Any(e => e.Equals(point))) return;
        outgoing.Add(point);
    }

    public void RemoveOutgoing(Point point) 
    {
        outgoing.RemoveAll(e => e.Equals(point));
    }

    public bool HasNothing()
    {
        return incoming.Count() == 0 && outgoing.Count() == 0;
    }
}

