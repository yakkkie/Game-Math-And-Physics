using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    // Start is called before the first frame update

    private HMatrix2D mat = new HMatrix2D();
    private HMatrix2D mat1 = new HMatrix2D(2,1,3,2,1,3,2,1,3);
    private HMatrix2D mat2 = new HMatrix2D();
    private HVector2D vec = new HVector2D(2, 2);
    private HVector2D vec2 = new HVector2D();
    

    void Start()
    {
        //mat.setIdentity();
        //mat.Print();

        
        RandomMatrix(mat2);
        mat1.Print();
        mat2.Print();

        vec2 = mat1 * vec;

        mat = mat1 * mat2;

        mat.Print();

        Debug.Log(vec2.x + "\t" + vec2.y);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    HMatrix2D RandomMatrix(HMatrix2D mat)
    {
        for (int i = 0; i < mat1.entries.GetLength(1); i++)
        {
            for (int j = 0; j < mat1.entries.GetLength(0); j++)
            {
                mat.entries[i, j] = Random.Range(1, 100);
            }
        }
        return mat;
    }
}
