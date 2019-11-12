using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Circle : Shape
{

    public Circle(Vector2 center, float radius)
    {
        this.center = center;
        this.radius = radius;
    }


    public float radius;
}
