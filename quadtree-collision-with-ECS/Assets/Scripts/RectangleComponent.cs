using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct RectangleComponent: IComponentData
{
    public float3 center;
    public float3 velocity;
    public int width;
    public float height;
}
