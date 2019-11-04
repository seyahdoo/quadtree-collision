using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    public enum CollisionDetectionMode
    {
        QuadtreeAllocated,
        QuadtreeNonAllocated,
        Conventional
    }
    public static CollisionDetectionMode mode = CollisionDetectionMode.QuadtreeNonAllocated;

    public static bool debugDrawShapes = true;
    public static bool debugDrawTree = true;

}
