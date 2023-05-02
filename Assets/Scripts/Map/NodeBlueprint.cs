using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType
{
    SPIRIT,
    IFRIT,
    BOSS,
    CAMPFIRE,
    TREASURE,
    MYSTERY
}

[CreateAssetMenu]
public class NodeBlueprint : ScriptableObject
{
    public Sprite sprite;
    public NodeType nodeType;

}
