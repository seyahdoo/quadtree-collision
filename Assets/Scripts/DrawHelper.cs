using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHelper : MonoBehaviour
{

    const int CircleSubdivision = 15;

    public static void DrawShape(Shape s, Color c)
    {
        if (s.GetType() == typeof(Circle))
        {
            DrawCircle(s as Circle, c);
        }
        else if (s.GetType() == typeof(Rectangle))
        {
            DrawRect(s as Rectangle, c);
        }
    }

    static void DrawRect(Rectangle r, Color c)
    {
        //lb - lu
        Debug.DrawLine(new Vector3(r.center.x - r.width / 2, r.center.y - r.height / 2), new Vector3(r.center.x - r.width / 2, r.center.y + r.height / 2), c, Time.deltaTime);

        //rb - ru
        Debug.DrawLine(new Vector3(r.center.x + r.width / 2, r.center.y - r.height / 2), new Vector3(r.center.x + r.width / 2, r.center.y + r.height / 2), c, Time.deltaTime);

        //lu - ru
        Debug.DrawLine(new Vector3(r.center.x - r.width / 2, r.center.y + r.height / 2), new Vector3(r.center.x + r.width / 2, r.center.y + r.height / 2), c, Time.deltaTime);

        //lb - rb
        Debug.DrawLine(new Vector3(r.center.x - r.width / 2, r.center.y - r.height / 2), new Vector3(r.center.x + r.width / 2, r.center.y - r.height / 2), c, Time.deltaTime);
    }

    static void DrawCircle(Circle s, Color c)
    {

        for (int i = 0; i < 360; i += 360/CircleSubdivision)
        {
            Debug.DrawLine(
                new Vector3(s.center.x + Mathf.Sin(Mathf.Deg2Rad * i) * s.radius, s.center.y + Mathf.Cos(Mathf.Deg2Rad * i) * s.radius),
                new Vector3(s.center.x + Mathf.Sin(Mathf.Deg2Rad * (i + (360 / CircleSubdivision))) * s.radius, s.center.y + Mathf.Cos(Mathf.Deg2Rad * (i + (360 / CircleSubdivision))) * s.radius),
                c,
                Time.deltaTime
                );
        }

    }


}
