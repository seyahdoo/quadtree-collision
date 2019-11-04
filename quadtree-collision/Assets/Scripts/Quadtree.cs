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

        bool inserted = false;

        if (tl.Insert(s)) inserted = true;
        if (tr.Insert(s)) inserted = true;
        if (bl.Insert(s)) inserted = true;
        if (br.Insert(s)) inserted = true;

        return inserted;
    }

    public void Subdivide()
    {
        tr = new Quadtree(new Rectangle(new Vector2(boundry.center.x + boundry.width / 4, boundry.center.y + boundry.height / 4), boundry.width / 2, boundry.height / 2), capacity);
        br = new Quadtree(new Rectangle(new Vector2(boundry.center.x + boundry.width / 4, boundry.center.y - boundry.height / 4), boundry.width / 2, boundry.height / 2), capacity);
        tl = new Quadtree(new Rectangle(new Vector2(boundry.center.x - boundry.width / 4, boundry.center.y + boundry.height / 4), boundry.width / 2, boundry.height / 2), capacity);
        bl = new Quadtree(new Rectangle(new Vector2(boundry.center.x - boundry.width / 4, boundry.center.y - boundry.height / 4), boundry.width / 2, boundry.height / 2), capacity);
        subdivided = true;
    }

    public void Search(Shape s)
    {
        if (!Collision.IsColliding(s, boundry))
        {
            return;
        }
        for (int i = 0; i < shapesCounter; i++)
        {
            if(s != shapes[i] && Collision.IsColliding(s, shapes[i]))
            {
                ShapeSystem.OnCollisionEnter(s, shapes[i]);
            }
        }
        if (subdivided)
        {
            tl.Search(s);
            tr.Search(s);
            bl.Search(s);
            br.Search(s);
        }
    }

    public void Clear()
    {
        shapesCounter = 0;
        for (int i = 0; i < shapes.Length; i++)
        {
            shapes[i] = null;
        }

        if (subdivided)
        {
            tl.Clear();
            tr.Clear();
            bl.Clear();
            br.Clear();
        }
    }

    public void Resize(float centerX, float centerY, float width, float height)
    {
        this.boundry.center.x = centerX;
        this.boundry.center.y = centerY;
        this.boundry.width = width;
        this.boundry.height = height;

        if (subdivided)
        {
            tr.Resize(boundry.center.x + boundry.width / 4, boundry.center.y + boundry.height / 4, boundry.width / 2, boundry.height / 2);
            br.Resize(boundry.center.x + boundry.width / 4, boundry.center.y - boundry.height / 4, boundry.width / 2, boundry.height / 2); tr.Resize(boundry.center.x + boundry.width / 4, boundry.center.y + boundry.height / 4, boundry.width / 2, boundry.height / 2);
            tl.Resize(boundry.center.x - boundry.width / 4, boundry.center.y + boundry.height / 4, boundry.width / 2, boundry.height / 2);
            bl.Resize(boundry.center.x - boundry.width / 4, boundry.center.y - boundry.height / 4, boundry.width / 2, boundry.height / 2);
        }
    }

    public void ClearEmptySubdivisions()
    {
        if(subdivided == true)
        {
            tl.ClearEmptySubdivisions();
            tr.ClearEmptySubdivisions();
            bl.ClearEmptySubdivisions();
            br.ClearEmptySubdivisions();

            if ( this.shapesCounter +
                tl.shapesCounter +
                tr.shapesCounter +
                bl.shapesCounter +
                br.shapesCounter <= 4)
            {
                for (int i = 0; i < tl.shapesCounter; i++)
                {
                    shapes[shapesCounter] = tl.shapes[i];
                    shapesCounter++;
                }
                tl = null;

                for (int i = 0; i < bl.shapesCounter; i++)
                {
                    shapes[shapesCounter] = bl.shapes[i];
                    shapesCounter++;
                }
                bl = null;

                for (int i = 0; i < tr.shapesCounter; i++)
                {
                    shapes[shapesCounter] = tr.shapes[i];
                    shapesCounter++;
                }
                tr = null;

                for (int i = 0; i < br.shapesCounter; i++)
                {
                    shapes[shapesCounter] = br.shapes[i];
                    shapesCounter++;
                }
                tl = null;

                subdivided = false;
            }
        }
    }
    
    public void Draw()
    {
        DrawHelper.DrawShape(boundry, Color.white);
        if (subdivided)
        {
            tl.Draw();
            tr.Draw();
            bl.Draw();
            br.Draw();
        }
    }

}
