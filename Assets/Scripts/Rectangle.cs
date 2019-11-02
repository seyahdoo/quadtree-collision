using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Rectangle : Shape
{

    public Rectangle(Vector2 center, float height, float width)
    {
        this.center = center;
        this.height = height;
        this.width = width;
    }

    public float height;
    public float width;
}
