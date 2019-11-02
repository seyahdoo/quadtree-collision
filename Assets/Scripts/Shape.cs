﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shape
{
    public Vector2 center;

    public void OnCollisionEnter(Shape other)
    {
        //Debug.Log("Collided!");
    }

}
