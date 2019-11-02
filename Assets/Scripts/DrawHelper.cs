using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHelper : MonoBehaviour
{

    const int CircleSubdivision = 15;

    public static void DrawShape(Shape s){
        if (s.GetType() == typeof(Circle))
        {
            DrawCircle(s as Circle);
        }
        else if (s.GetType() == typeof(Rectangle))
        {
            DrawRect(s as Rectangle);
        }
    }

    static void DrawRect(Rectangle r)
    {
        Debug.DrawLine(new Vector3(r.center.x - r.height / 2, r.center.y + r.width / 2), new Vector3(r.center.x + r.height / 2, r.center.y + r.width / 2), Color.blue, Time.deltaTime);
        Debug.DrawLine(new Vector3(r.center.x - r.height / 2, r.center.y - r.width / 2), new Vector3(r.center.x + r.height / 2, r.center.y - r.width / 2), Color.blue, Time.deltaTime);
        Debug.DrawLine(new Vector3(r.center.x - r.height / 2, r.center.y + r.width / 2), new Vector3(r.center.x - r.height / 2, r.center.y - r.width / 2), Color.blue, Time.deltaTime);
        Debug.DrawLine(new Vector3(r.center.x + r.height / 2, r.center.y + r.width / 2), new Vector3(r.center.x + r.height / 2, r.center.y - r.width / 2), Color.blue, Time.deltaTime);
    }

    static void DrawCircle(Circle s)
    {

        for (int i = 0; i < 360; i += 360/CircleSubdivision)
        {
            Debug.DrawLine(
                new Vector3(s.center.x + Mathf.Sin(Mathf.Deg2Rad * i) * s.radius, s.center.y + Mathf.Cos(Mathf.Deg2Rad * i) * s.radius),
                new Vector3(s.center.x + Mathf.Sin(Mathf.Deg2Rad * (i + (360 / CircleSubdivision))) * s.radius, s.center.y + Mathf.Cos(Mathf.Deg2Rad * (i + (360 / CircleSubdivision))) * s.radius),
                Color.cyan,
                Time.deltaTime
                );
        }

    }


}
