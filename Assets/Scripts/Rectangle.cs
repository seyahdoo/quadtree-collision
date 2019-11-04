using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Rectangle : Shape
{

    public Rectangle(Vector2 center, float width, float height)
    {
        this.center = center;
        this.width = width;
        this.height = height;
    }

    public float width;
    public float height;
}
