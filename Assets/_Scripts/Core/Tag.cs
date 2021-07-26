using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tags
{
    None,
    Box,
    Obstacle,
    Player,
    Fuel,
    Enemy,
    MovingPlatform
}

public class Tag : MonoBehaviour
{
    [SerializeField] List<Tags> tags;
    public List<Tags> Tags => tags;
}