using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    // Start is called before the first frame update

    private HMatrix2D mat = new HMatrix2D();
    private HMatrix2D mat1 = new HMatrix2D();
    private HMatrix2D mat2 = new HMatrix2D();

    

    void Start()
    {
        //mat.setIdentity();
        //mat.Print();

        RandomMatrix(mat1);
        RandomMatrix(mat2);
        mat1.Print();
        mat2.Print();

        mat = mat1 * mat2;

        mat.Print();

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
