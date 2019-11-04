using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ShapeSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref CircleComponent circleComponent) => {
            //circleComponent.center.x += 1;

        });


    }

}
