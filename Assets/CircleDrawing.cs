using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrawing : MonoBehaviour
{

    public Circle circle = new Circle();

    void Update()
    {
        circle.center = transform.position;
        circle.radius = transform.localScale.x/2;
    }
}
