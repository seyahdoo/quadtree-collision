using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using E7.ECS.LineRenderer;
using Unity.Transforms;
using Unity.Rendering;

public class Tester : MonoBehaviour
{
    public Mesh mesh;
    public Material squareMaterial;
    public Material circleMaterial;

    void Start()
    {
        Collision.IsColliding(CreateCircle(new Vector2(0,0),2f), CreateSquare(new Vector2(1,1), 1, 1));

    }

    public Entity CreateCircle(Vector2 pos, float diameter)
    {
        EntityManager em = World.Active.EntityManager;
        EntityArchetype circleArchetype = em.CreateArchetype(
            typeof(CircleComponent),
            typeof(HealthComponent),
            typeof(RenderMesh),
            typeof(Translation),
            typeof(LocalToWorld),
            typeof(Scale));

        var entitiy = em.CreateEntity(circleArchetype);
        em.SetComponentData(entitiy, new Translation { Value = new float3(pos.x, pos.y, 0f) });
        em.SetComponentData(entitiy, new Scale { Value = diameter });
        em.SetComponentData(entitiy, new HealthComponent { health = 5 });
        em.SetComponentData(entitiy, new Scale { Value = 1f });
        em.SetSharedComponentData(entitiy, new RenderMesh { material = circleMaterial, mesh = mesh });
        return entitiy;
    }

    public Entity CreateSquare(Vector2 pos, float width, float height)
    {
        EntityManager em = World.Active.EntityManager;
        EntityArchetype rectangleArchetype = em.CreateArchetype(
            typeof(RectangleComponent),
            typeof(HealthComponent),
            typeof(RenderMesh),
            typeof(Translation),
            typeof(LocalToWorld),
            typeof(NonUniformScale));
        Entity entitiy = em.CreateEntity(rectangleArchetype);
        em.SetComponentData(entitiy, new Translation { Value = new float3(pos.x, pos.y, 0f) });
        em.SetComponentData(entitiy, new NonUniformScale { Value = new float3(width, height, 0f) });
        em.SetComponentData(entitiy, new HealthComponent { health = 5 });
        em.SetSharedComponentData(entitiy, new RenderMesh { material = squareMaterial, mesh = mesh });
        return entitiy;
    }


}
