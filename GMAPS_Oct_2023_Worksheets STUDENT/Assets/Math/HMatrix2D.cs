using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3,3];

    
    public HMatrix2D()
    {
        // your code here
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < multiArray.GetLength(1); y++)
        {
            for (int x = 0; x < multiArray.GetLength(0); x++)
            {
                entries[y,x] = multiArray[y,x];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row
        entries[0,0] = m00;
        entries[0,1] = m01;
        entries[0,2] = m02;

        // Second row
        entries[1,0] = m10;
        entries[1,1] = m11;
        entries[1,2] = m12;

        // Third row
        entries[2,0] = m20;
        entries[2,1] = m21;
        entries[2,2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();
        for (int y = 0; y < left.entries.GetLength(0); y++)
        {
            for (int x = 0; x < left.entries.GetLength(1); x++)
            {
                result.entries[y , x] = left.entries[y,x] + right.entries[y,x];
            }
        }
        return result;
    }
    
    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();
        for (int y = 0; y < left.entries.GetLength(0); y++)
        {
            for (int x = 0; x < left.entries.GetLength(1); x++)
            {
                result.entries[y, x] = left.entries[y, x] - right.entries[y, x];
            }
        }
        return result;
    }
    
    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {

        HMatrix2D result = new HMatrix2D();
        for (int y = 0; y < left.entries.GetLength(0); y++)
        {
            for (int x = 0; x < left.entries.GetLength(1); x++)
            {
                result.entries[y, x] = left.entries[y, x] * scalar;
            }
        }
        return result;
    }
    
    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        HVector2D result = new HVector2D();
        for (int y = 0; y < left.entries.GetLength(0); y++)
        {
            for (int x = 0; x < left.entries.GetLength(1); x++)
            {
                if(y == 0)
                {
                    result.x += right.x * left.entries[y, x];
                }
                if (y == 1)
                {
                    result.y += right.y * left.entries[y, x];
                }
            }
        }
        return result;
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            /* 
                00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx
                */


            /* 
                00 01 02    xx 01 xx
                xx xx xx    xx 11 xx
                xx xx xx    xx 21 xx
                */
            left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],
            left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],
            left.entries[0, 0] * right.entries[0,2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

            left.entries[1,0] * right.entries[0,0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1,2] * right.entries[2,0],
            left.entries[1,0] * right.entries[0,1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1,2] * right.entries[2,1],
            left.entries[1,0] * right.entries[0,2] + left.entries[1, 1] * right.entries[1,2] + left.entries[1, 2] * right.entries[2,2],

            left.entries[2,0] * right.entries[0, 0] + left.entries[2,1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],
            left.entries[2,0] * right.entries[0, 1] + left.entries[2,1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],
            left.entries[2,0] * right.entries[0, 2] + left.entries[2,1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]




        // and so on for another 7 entries
    );
    }
    //
    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {

        for (int i = 0; i < left.entries.GetLength(1); i++)
        {
            for (int j = 0; j < left.entries.GetLength(0); j++)
            {
                if (left.entries[i,j] != right.entries[i, j])
                {
                    return false;
                }
            }
        }

        return left.entries == right.entries;
        // your code here
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int i = 0; i < left.entries.GetLength(1); i++)
        {
            for (int j = 0; j < left.entries.GetLength(0); j++)
            {
                if (left.entries[i, j] == right.entries[i, j])
                {
                    return false;
                }
            }
        }
        return left.entries != right.entries;
    }

    public override bool Equals(object obj)
    {
        if(!(obj is HMatrix2D))
        {
            return false;
        }

        return true;
    }

    //public override int GetHashCode()
    //{
    //    // your code here
    //}
    //
    //public HMatrix2D transpose()
    //{
    //    return // your code here
    //}
    //
    //public float getDeterminant()
    //{
    //    return // your code here
    //}
    //
    public void setIdentity()
    {
        for (int y = 0; y < entries.GetLength(1) ; y++)
        {
            for (int x = 0; x < entries.GetLength(0); x++)
            {
                entries[y,x] = x == y? 1 : 0;
            }
        }

    }
    
    //public void setTranslationMat(float transX, float transY)
    //{
    //    // your code here
    //}
    //
    //public void setRotationMat(float rotDeg)
    //{
    //    // your code here
    //}
    //
    //public void setScalingMat(float scaleX, float scaleY)
    //{
    //    // your code here
    //}
    //
    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}