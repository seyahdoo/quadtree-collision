using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{

    public RectDrawing r1;
    public RectDrawing r2;

    public CircleDrawing c1;
    public CircleDrawing c2;


    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {

         print(Collision.IsColliding(c1.circle, r1.rect));

    }
}
