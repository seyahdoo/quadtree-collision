using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using E7.ECS.LineRenderer;
using Unity.Transforms;

public class Tester : MonoBehaviour
{

    void Start()
    {
        EntityManager em = World.Active.EntityManager;

        EntityArchetype entityArchetype = em.CreateArchetype(typeof(RectangleComponent), typeof(HealthComponent));
        Entity entitiy = em.CreateEntity(entityArchetype);
        em.SetComponentData<HealthComponent>(entitiy, new HealthComponent { health = 5});

        var mat = UnityEditor.AssetDatabase.LoadAssetAtPath<Material>("Packages/com.e7.ecs.line-renderer/Samples/SampleLineMaterial.mat");

        var e = em.CreateEntity();
        em.AddComponentData(e, new LineSegment(math.float3(0, 0, 0), math.float3(0, 1, 0), .03f));
        em.AddComponentData(e, new Parent { Value = entitiy });
        em.AddSharedComponentData(e, new LineStyle { material = mat });

        e = em.CreateEntity();
        em.AddComponentData(e, new LineSegment(math.float3(0, 1, 0), math.float3(1, 1, 0), .03f));
        em.AddComponentData(e, new Parent { Value = entitiy });
        em.AddSharedComponentData(e, new LineStyle { material = mat });


        e = em.CreateEntity();
        em.AddComponentData(e, new LineSegment(math.float3(1, 1, 0), math.float3(1, 0, 0), .03f));
        em.AddComponentData(e, new Parent { Value = entitiy });
        em.AddSharedComponentData(e, new LineStyle { material = mat });


        e = em.CreateEntity();
        em.AddComponentData(e, new LineSegment(math.float3(1, 0, 0), math.float3(0, 0, 0), .03f));
        em.AddComponentData(e, new Parent { Value = entitiy });
        em.AddSharedComponentData(e, new LineStyle { material = mat });


    }

}
