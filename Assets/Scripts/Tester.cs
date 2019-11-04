using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        if (Input.anyKey)
        {
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 p = r.GetPoint(10);
            ShapeSystem.SpawnShape(new Circle(p, Random.Range(1f, 4f)));
        }

        ShapeSystem.Update();

        if (Input.GetKeyDown(KeyCode.F1))
        {
            long quadtreeResult = BenchmarkHelper.Benchmark(() => { CollisionDetectionSystem.QuadtreeTest(); }, 10);
            long quadtreeNonAllocResult = BenchmarkHelper.Benchmark(() => { CollisionDetectionSystem.QuadtreeNonAllocTest(); }, 10);
            long conventionalResult = BenchmarkHelper.Benchmark(() => { CollisionDetectionSystem.ConventionalTest(); }, 10);
            print("Quadtree Benchmark Time: " + quadtreeResult);
            print("Quadtree(Non Alloc) Benchmark Time: " + quadtreeNonAllocResult);
            print("Conventional Benchmark Time: " + conventionalResult);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            Settings.mode = Settings.CollisionDetectionMode.Conventional; 
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            Settings.mode = Settings.CollisionDetectionMode.QuadtreeAllocated;
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            Settings.mode = Settings.CollisionDetectionMode.QuadtreeNonAllocated;
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            Settings.debugDrawShapes = !Settings.debugDrawShapes;
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            Settings.debugDrawTree = !Settings.debugDrawTree;
        }

        CollisionDetectionSystem.DetectCollisions();

        //cam.transform.position = new Vector3(q.boundry.center.x, q.boundry.center.y, -10f);
        //cam.orthographicSize = Mathf.Clamp(q.boundry.height, 1f, 100f);
    }

    

}
