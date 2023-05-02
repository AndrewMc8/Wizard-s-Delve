using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLayer
{
    public NodeType nodeType;
    public FloatMinMax distanceFromLastLayer;
    public float distanceBetween;
    [Range(0f, 1f)] public float randomPosition;
    [Range(0f, 1f)] public float randomNode;
}
