using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection.Emit;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

     public static HVector2D operator +(HVector2D _vec1, HVector2D _vec2)
     {
        return new HVector2D(_vec1.x + _vec2.x, _vec1.y + _vec2.y);
     }

     public static HVector2D operator -(HVector2D _vec1, HVector2D _vec2)
     {
        return new HVector2D(_vec1.x - _vec2.x, _vec1.y - _vec2.y);
     }

     public static HVector2D operator *(HVector2D _vec1, float scale)
     {

        return new HVector2D(_vec1.x * scale, _vec1.y * scale);
    }
     public static HVector2D operator /(HVector2D _vec1, float div)
     {
        return new HVector2D(_vec1.x / div, _vec1.y / div);
    }
    //public static List<T> operator +(List<T> a, List<T> b)
    //{
    //    List<T> c = new List<T> ();
    //    foreach (var item in a)
    //    {
    //        c.Add (item);
    //    }
    //    foreach (var item in b)
    //    {
    //        c.Add(item);
    //    }
    //
    //}

     public float Magnitude()
     {
        float xsquare = x * x;
        float ysquare = y * y;
        return (float)Math.Sqrt(xsquare + ysquare);
        
     }

     public void Normalize()
     {

     
        float mag = Magnitude();
        x /= mag;
        y /= mag;


     }

    public float DotProduct(HVector2D vec1)
    {
        float dotProduct = vec1.x * x + vec1.y * y;
        return dotProduct;
    }

    public HVector2D Projection(HVector2D vec1)
    {
        float dot = DotProduct(vec1);

        HVector2D proj = vec1 * (dot / vec1.DotProduct(vec1));
        return proj;
    }

     public float FindAngle(HVector2D vec)
     {
        double angle = Math.Acos(DotProduct(vec)/ (Magnitude() * vec.Magnitude())) * Mathf.Rad2Deg;
        return (float)angle;
     }


   // public float SignedAngle(HVector2D from, HVector2D to)
   //{
   //    float dot = from.DotProduct(to);
   //    float angle = FindAngle(dot);
   //    float sign = Math.Sign(dot);
   //    return angle * sign;
   //
   //}

    public Vector2 ToUnityVector2()
    {
        return Vector2.zero; // change this
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(x, y, 0); // change this
    }

    // public void Print()
    // {

    // }
}
