using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct CircleComponent: IComponentData
{
    public float3 center;
    public float3 velocity;
    public float radius;
}
