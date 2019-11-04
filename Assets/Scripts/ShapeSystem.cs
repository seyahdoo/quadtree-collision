﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShapeSystem
{

    public static HashSet<Shape> shapes = new HashSet<Shape>();

    public static void SpawnShape(Shape s)
    {
        s.velocity = Random.insideUnitCircle * 4f;
        shapes.Add(s);
    }

    public static void SpawnRandomShape()
    {
        if(Random.Range(0f, 1f) > .5f)
        {
            SpawnShape(new Circle(new Vector2(Random.Range(-100f, 100f), Random.Range(-100f,100f)), Random.Range(1f, 4f)));
        }
        else
        {
            SpawnShape(new Rectangle(new Vector2(Random.Range(-100f, 100f), Random.Range(-100f, 100f)), Random.Range(1f, 4f), Random.Range(1f, 4f)));
        }
    }

    public static void Update()
    {
        int removedCount = shapes.RemoveWhere((Shape s) => 
        {
           return (
            s.health <= 0) || 
            Mathf.Abs(s.center.x) > 100f || 
            Mathf.Abs(s.center.y) > 100f;
            }
        );

        for (int i = 0; i < removedCount; i++)
        {
            SpawnRandomShape();
        }

        foreach (var s in shapes)
        {
            s.center += s.velocity * Time.deltaTime;
            if (Settings.debugDrawShapes) DrawHelper.DrawShape(s, Color.blue);
        }
    }

    public static void OnCollisionEnter(Shape s1, Shape s2)
    {
        s1.velocity = (s1.center - s2.center).normalized * s1.velocity.magnitude;
        if (Settings.debugDrawShapes) DrawHelper.DrawShape(s1, Color.red);

        s1.health--;

    }



}
