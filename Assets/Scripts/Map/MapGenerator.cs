using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapGenerator
{
    public static MapConfig config;

    private static readonly List<NodeType> randomNodes = new List<NodeType>() 
    { NodeType.MYSTERY, NodeType.TREASURE, NodeType.SPIRIT, NodeType.CAMPFIRE };

    private static List<float> layerDistance;
    private static List<List<Point>> paths;

    private static List<List<Node>> nodes = new List<List<Node>>();

    public static Map GetMap(MapConfig con)
    {
        if (config == null) 
        {
            return null;
        }

        config = con;
        nodes.Clear();

        GenerateLayerDistance();

        for(int i = 0; i < con.layers.Count; i++) 
        {
            PlaceLayer(i);
        }

        GeneratePaths();

        RandomizeNodePos();

        SetUpConnections();

        RemoveCrossConnections();

        var nodesList = nodes.SelectMany(n => n).Where(n => n.incoming.Count > 0 || n.outgoing.Count > 0).ToList();

        return new Map(nodesList, new List<Point>(), con.name);
    }

    private static void GenerateLayerDistance()
    {
        layerDistance = new List<float>();
        foreach(var layer in config.layers)
        {
            layerDistance.Add(layer.distanceFromLastLayer.GetValue());
        }
    }
    private static void PlaceLayer(int layerIndex)
    {
        var layer = config.layers[layerIndex];
        var nodesOnCurrentLayer = new List<Node>();

        var offset = layer.distanceBetween * config.GridWidth / 2f;

        for(int i = 0; i < config.GridWidth; i++) 
        {
            var nodeType = UnityEngine.Random.Range(0f, 1f) < layer.randomNode ? GetRandomNode() : layer.nodeType;
            var blueprintName = config.nodeBlueprints.Where(b => b.nodeType == nodeType).ToList().Random().name;
            var node = new Node(nodeType, blueprintName, new Point(i, layerIndex))
            {
                position = new Vector2(-offset + i * layer.distanceBetween, GetDistanceToLayer(layerIndex))
            };
            nodesOnCurrentLayer.Add(node);
        }

        nodes.Add(nodesOnCurrentLayer);
    }

    private static void GeneratePaths()
    {
        throw new NotImplementedException();
    }

    private static void RandomizeNodePos()
    {
        throw new NotImplementedException();
    }

    private static void SetUpConnections()
    {
        throw new NotImplementedException();
    }
    private static void RemoveCrossConnections()
    {
        throw new NotImplementedException();
    }

    private static NodeType GetRandomNode()
    {
        return randomNodes[UnityEngine.Random.Range(0, randomNodes.Count)];
    }

    private static float GetDistanceToLayer(int layerIndex)
    {
        if (layerIndex < 0 || layerIndex > layerDistance.Count) return 0f;

        return layerDistance.Take(layerIndex + 1).Sum();
    }
}
