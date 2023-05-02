using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map
{
    public List<Node> nodes;
    public List<Point> path;
    public string bossName;

    public Map(List<Node> nodes, List<Point> path, string bossName)
    {
        this.nodes = nodes;
        this.path = path;
        this.bossName = bossName;
    }

    public Node GetBossNode()
    {
        return nodes.FirstOrDefault(n => n.nodeType == NodeType.BOSS);
    }

    public float LayerDistanceForFirstAndLastNodes()
    {
        var bossNode = GetBossNode();
        var firstLayerNode = nodes.FirstOrDefault(n => n.point.y == 0);

        if (bossNode == null || firstLayerNode == null) return 0;

        return bossNode.position.y - firstLayerNode.position.y;
    }

    public Node GetNode(Point point)
    {
        return nodes.FirstOrDefault(n => n.point.Equals(point));
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
    }
}
