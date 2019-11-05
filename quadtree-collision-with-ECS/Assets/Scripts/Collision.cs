using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public static class Collision
{
    
    public static bool IsColliding (Entity e1, Entity e2)
    {
        EntityManager em = World.Active.EntityManager;

        var e1Types = em.GetComponentTypes(e1);
        var e2Types = em.GetComponentTypes(e2);

        for (int i = 0; i < e1Types.Length; i++)
        {
            if(e1Types[i].GetType() == typeof(CircleComponent))
            {
                Debug.Log("asdasdasd");
            }

        }

        return true;

        //    if (shape.GetType() == typeof(Circle))
        //    {
        //        if(other.GetType() == typeof(Circle))
        //        {
        //            return CircleCircleIsColliding((Circle)shape, (Circle)other);
        //        }
        //        else
        //        {
        //            return RectCircleIsColliding((Rectangle)other, (Circle)shape);
        //        }
        //    }
        //    else if (other.GetType() == typeof(Rectangle))
        //    {
        //        return RectRectIsColliding((Rectangle)shape, (Rectangle)other);
        //    }
        //    return RectCircleIsColliding((Rectangle)shape, (Circle)other);
    }


    //public static bool RectRectIsColliding (Rectangle r1, Rectangle r2)
    //{
    //    return 
    //       r1.center.x - r1.width / 2 < r2.center.x + r2.width / 2 &&
    //       r1.center.x + r1.width / 2 > r2.center.x - r2.width / 2 &&
    //       r1.center.y - r1.height / 2 < r2.center.y + r2.height / 2 &&
    //       r1.center.y + r1.height / 2 > r2.center.y - r2.height / 2;
    //}


    //public static bool CircleCircleIsColliding(Circle r1, Circle r2)
    //{
    //    float dist = Vector2.Distance(r1.center, r2.center);
    //    return dist < r1.radius + r2.radius;
    //}


    //public static bool RectCircleIsColliding(Rectangle r, Circle c)
    //{
    //    Vector2 v = new Vector2
    //    {
    //        x = Mathf.Clamp(c.center.x, r.center.x - r.width / 2, r.center.x + r.width / 2),
    //        y = Mathf.Clamp(c.center.y, r.center.y - r.height / 2, r.center.y + r.height / 2)
    //    };
    //    float dist = Vector2.Distance(c.center, v);
    //    return dist < c.radius;
    //}


}
