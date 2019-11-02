using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{

    public Quadtree q;
    public HashSet<Shape> shapes = new HashSet<Shape>();
    public Camera cam;

    void Update()
    {

        if (Input.anyKey)
        {
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 p = r.GetPoint(10);
            Circle c = new Circle(p, Random.Range(1f, 4f));
            shapes.Add(c);
        }

        q = new Quadtree(new Rectangle(Vector2.zero, 100, 100), 4);
        foreach (var s in shapes)
        {
            q.Insert(s);
            DrawHelper.DrawShape(s);
        }
        q.Draw();

        foreach (var s in shapes)
        {
            q.Search(s);
        }


    }
}
