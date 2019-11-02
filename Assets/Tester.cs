using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{

    public Shape s;
    public Circle c;
    
    // Start is called before the first frame update
    void Start()
    {
        //Rectangle r = new Rectangle();
        //r.center = new Vector2(0, 0);
        //r.height = 2f;
        //r.width = 1f;
        //s = r;

        c = new Circle();

    }

    // Update is called once per frame
    void Update()
    {

        //DrawHelper.DrawShape(s);
        DrawHelper.DrawShape(c);
        //print(Collision.IsColliding(, ));

    }
}
