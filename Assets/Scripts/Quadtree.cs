using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadtree
{

    public Rectangle boundry;
    public int capacity;

    public Shape[] shapes;
    public int shapesCounter = 0;

    public bool subdivided = false;
    public Quadtree tl;
    public Quadtree tr;
    public Quadtree bl;
    public Quadtree br;

    public Quadtree(Rectangle boundry, int capacity)
    {
        this.boundry = boundry;
        this.capacity = capacity;
        shapes = new Shape[capacity];
    }

    public bool Insert(Shape s)
    {
        if(!Collision.IsColliding(boundry, s))
        {
            return false;
        }

        if (shapesCounter < capacity)
        {
            shapes[shapesCounter] = s;
            shapesCounter++;
            return true;
        }

        if (!subdivided)
        {
            Subdivide();
        }

        if (tl.Insert(s)) return true;
        else if (tr.Insert(s)) return true;
        else if (bl.Insert(s)) return true;
        else if (br.Insert(s)) return true;

        return false;
    }

    public void Subdivide()
    {
        tl = new Quadtree(new Rectangle(new Vector2(boundry.center.x + boundry.height / 4, boundry.center.y - boundry.width / 4), boundry.height / 2, boundry.width / 2), capacity);
        tr = new Quadtree(new Rectangle(new Vector2(boundry.center.x + boundry.height / 4, boundry.center.y + boundry.width / 4), boundry.height / 2, boundry.width / 2), capacity);
        bl = new Quadtree(new Rectangle(new Vector2(boundry.center.x - boundry.height / 4, boundry.center.y - boundry.width / 4), boundry.height / 2, boundry.width / 2), capacity);
        br = new Quadtree(new Rectangle(new Vector2(boundry.center.x - boundry.height / 4, boundry.center.y + boundry.width / 4), boundry.height / 2, boundry.width / 2), capacity);
        subdivided = true;
    }

    public void Draw()
    {
        DrawHelper.DrawShape(boundry);
        if (subdivided)
        {
            tl.Draw();
            tr.Draw();
            bl.Draw();
            br.Draw();
        }
    }

}
