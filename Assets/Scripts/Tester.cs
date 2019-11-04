using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Quadtree q;
    public HashSet<Shape> shapes = new HashSet<Shape>();
    public Camera cam;

    public enum CollisionDetectionMode
    {
        QuadtreeAllocated,
        QuadtreeNonAllocated,
        Conventional
    }
    public CollisionDetectionMode mode = CollisionDetectionMode.QuadtreeNonAllocated;

    public bool debugDrawShapes = false;
    public bool debugDrawTree = false;

    private void Awake()
    {
        q = new Quadtree(new Rectangle(Vector2.zero, 0f, 0f), 4);
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 p = r.GetPoint(10);
            Circle c = new Circle(p, Random.Range(1f, 4f));
            c.velocity = Random.insideUnitCircle * 4f;
            shapes.Add(c);
        }
        foreach (var s in shapes)
        {
            s.center += s.velocity * Time.deltaTime;
            if (debugDrawShapes) DrawHelper.DrawShape(s, Color.blue);
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            long quadtreeResult = BenchmarkHelper.Benchmark(() => { QuadtreeTest(); }, 10);
            long quadtreeNonAllocResult = BenchmarkHelper.Benchmark(() => { QuadtreeNonAllocTest(); }, 10);
            long conventionalResult = BenchmarkHelper.Benchmark(() => { ConventionalTest(); }, 10);
            print("Quadtree Benchmark Time: " + quadtreeResult);
            print("Quadtree(Non Alloc) Benchmark Time: " + quadtreeNonAllocResult);
            print("Conventional Benchmark Time: " + conventionalResult);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            mode = CollisionDetectionMode.Conventional; 
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            mode = CollisionDetectionMode.QuadtreeAllocated;
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            mode = CollisionDetectionMode.QuadtreeNonAllocated;
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            debugDrawShapes = !debugDrawShapes;
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            debugDrawTree = !debugDrawTree;
        }

        switch (mode)
        {
            case CollisionDetectionMode.QuadtreeAllocated:
                QuadtreeTest();
                break;
            case CollisionDetectionMode.QuadtreeNonAllocated:
                QuadtreeNonAllocTest();
                break;
            case CollisionDetectionMode.Conventional:
                ConventionalTest();
                break;
        }

        //cam.transform.position = new Vector3(q.boundry.center.x, q.boundry.center.y, -10f);
        //cam.orthographicSize = Mathf.Clamp(q.boundry.height, 1f, 100f);
    }

    void QuadtreeTest()
    {
        float topBoundry = float.MinValue;
        float bottomBoundry = float.MaxValue;
        float leftBoundry = float.MaxValue;
        float rightBoundry = float.MinValue;

        foreach (var s in shapes)
        {
            if (s.center.x > rightBoundry) rightBoundry = s.center.x;
            if (s.center.x < leftBoundry) leftBoundry = s.center.x;
            if (s.center.y > topBoundry) topBoundry = s.center.y;
            if (s.center.y < bottomBoundry) bottomBoundry = s.center.y;
        }

        q = new Quadtree(
            new Rectangle(new Vector2((rightBoundry + leftBoundry) / 2, (topBoundry + bottomBoundry) / 2),
            rightBoundry - leftBoundry,
            topBoundry - bottomBoundry),
            4);

        foreach (var s in shapes)
        {
            q.Insert(s);
        }

        if (debugDrawTree) q.Draw();


        foreach (var s in shapes)
        {
            q.Search(s);
        }
    }

    void QuadtreeNonAllocTest()
    {
        float topBoundry = float.MinValue;
        float bottomBoundry = float.MaxValue;
        float leftBoundry = float.MaxValue;
        float rightBoundry = float.MinValue;

        foreach (var s in shapes)
        {
            if (s.center.x > rightBoundry) rightBoundry = s.center.x;
            if (s.center.x < leftBoundry) leftBoundry = s.center.x;
            if (s.center.y > topBoundry) topBoundry = s.center.y;
            if (s.center.y < bottomBoundry) bottomBoundry = s.center.y;
        }

        q.Resize(
            (rightBoundry + leftBoundry) / 2,
            (topBoundry + bottomBoundry) / 2,
            rightBoundry - leftBoundry,
            topBoundry - bottomBoundry);

        q.Clear();

        foreach (var s in shapes)
        {
            q.Insert(s);
        }

        q.ClearEmptySubdivisions();

        if (debugDrawTree) q.Draw();

        foreach (var s in shapes)
        {
            q.Search(s);
        }
    }

    void ConventionalTest()
    {
        foreach (var s in shapes)
        {
            foreach (var other in shapes)
            {
                if (s != other && Collision.IsColliding(s, other))
                {
                    s.OnCollisionEnter(other);
                    other.OnCollisionEnter(s);
                }
            }
        }
    }

}
