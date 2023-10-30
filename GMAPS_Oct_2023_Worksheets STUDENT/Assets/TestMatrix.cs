using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    // Start is called before the first frame update

    private HMatrix2D mat = new HMatrix2D();
   // private HMatrix2D mat1 = new (12,1,21,31,32,131,312,34,3);
    

    void Start()
    {
        mat.setIdentity();
        mat.Print();
        //mat1.Print();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
