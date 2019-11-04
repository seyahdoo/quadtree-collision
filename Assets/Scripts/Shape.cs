using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shape
{
    public Vector2 center;
    public Vector2 velocity;
    short health = 5;

    public void OnCollisionEnter(Shape other)
    {
        this.velocity = (this.center - other.center).normalized * this.velocity.magnitude; 
        DrawHelper.DrawShape(this, Color.red);
    }

}
