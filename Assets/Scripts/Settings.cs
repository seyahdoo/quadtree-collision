using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    public enum CollisionDetectionMode
    {
        Conventional = 0,
        QuadtreeAllocated = 1,
        QuadtreeNonAllocated = 2
    }
    public static CollisionDetectionMode mode = CollisionDetectionMode.Conventional;

    public static int shapeCount = 100;

    public static bool debugDrawShapes = true;
    public static bool debugDrawTree = true;

}
