using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectDrawing : MonoBehaviour
{

    public Rectangle rect = new Rectangle();

    void Update()
    {
        rect.center = transform.position;
        rect.width = transform.localScale.x;
        rect.height = transform.localScale.y;
    }
}
