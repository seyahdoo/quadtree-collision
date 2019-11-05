using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollisionDetectionSystem
{

    //public static Quadtree q = new Quadtree(new Rectangle(Vector2.zero, 0f, 0f), 4);

    //public static void DetectCollisions()
    //{
    //    switch (Settings.mode)
    //    {
    //        case Settings.CollisionDetectionMode.QuadtreeAllocated:
    //            QuadtreeTest();
    //            break;
    //        case Settings.CollisionDetectionMode.QuadtreeNonAllocated:
    //            QuadtreeNonAllocTest();
    //            break;
    //        case Settings.CollisionDetectionMode.Conventional:
    //            ConventionalTest();
    //            break;
    //    }
    //}

    //public static void QuadtreeTest()
    //{
    //    float topBoundry = float.MinValue;
    //    float bottomBoundry = float.MaxValue;
    //    float leftBoundry = float.MaxValue;
    //    float rightBoundry = float.MinValue;

    //    foreach (var s in ShapeSystem.shapes)
    //    {
    //        if (s.center.x > rightBoundry) rightBoundry = s.center.x;
    //        if (s.center.x < leftBoundry) leftBoundry = s.center.x;
    //        if (s.center.y > topBoundry) topBoundry = s.center.y;
    //        if (s.center.y < bottomBoundry) bottomBoundry = s.center.y;
    //    }

    //    q = new Quadtree(
    //        new Rectangle(new Vector2((rightBoundry + leftBoundry) / 2, (topBoundry + bottomBoundry) / 2),
    //        rightBoundry - leftBoundry,
    //        topBoundry - bottomBoundry),
    //        4);

    //    foreach (var s in ShapeSystem.shapes)
    //    {
    //        q.Insert(s);
    //    }

    //    if (Settings.debugDrawTree) q.Draw();


    //    foreach (var s in ShapeSystem.shapes)
    //    {
    //        q.Search(s);
    //    }
    //}

    //public static void QuadtreeNonAllocTest()
    //{
    //    float topBoundry = float.MinValue;
    //    float bottomBoundry = float.MaxValue;
    //    float leftBoundry = float.MaxValue;
    //    float rightBoundry = float.MinValue;

    //    foreach (var s in ShapeSystem.shapes)
    //    {
    //        if (s.center.x > rightBoundry) rightBoundry = s.center.x;
    //        if (s.center.x < leftBoundry) leftBoundry = s.center.x;
    //        if (s.center.y > topBoundry) topBoundry = s.center.y;
    //        if (s.center.y < bottomBoundry) bottomBoundry = s.center.y;
    //    }

    //    q.Resize(
    //        (rightBoundry + leftBoundry) / 2,
    //        (topBoundry + bottomBoundry) / 2,
    //        rightBoundry - leftBoundry,
    //        topBoundry - bottomBoundry);

    //    q.Clear();

    //    foreach (var s in ShapeSystem.shapes)
    //    {
    //        q.Insert(s);
    //    }

    //    q.ClearEmptySubdivisions();

    //    if (Settings.debugDrawTree) q.Draw();

    //    foreach (var s in ShapeSystem.shapes)
    //    {
    //        q.Search(s);
    //    }
    //}

    //public static void ConventionalTest()
    //{
    //    foreach (var s in ShapeSystem.shapes)
    //    {
    //        foreach (var other in ShapeSystem.shapes)
    //        {
    //            if (s != other && Collision.IsColliding(s, other))
    //            {
    //                ShapeSystem.OnCollisionEnter(s, other);
    //            }
    //        }
    //    }
    //}


}
