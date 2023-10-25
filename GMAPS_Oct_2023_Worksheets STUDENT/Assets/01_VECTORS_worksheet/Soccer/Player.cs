using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Player : MonoBehaviour
{
    public bool IsCaptain = true;
    public Player OtherPlayer;

    float Magnitude(Vector3 vector)
    {
        float squareX = vector.x * vector.x;
        float squareY = vector.y * vector.y;
        float squareZ = vector.z * vector.z;

        return (float)Math.Sqrt(squareX + squareY + squareZ);
    }

    Vector3 Normalise(Vector3 vector)
    {
        float Mag = Magnitude(vector);
        float normX = vector.x / Mag;
        float normY = vector.y / Mag;
        float normZ = vector.z / Mag;

        return new Vector3(normX, normY, normZ);
    }

    float Dot(Vector3 vectorA, Vector3 vectorB)
    {
        float dot = (vectorA.x * vectorB.x + vectorA.y * vectorB.y + vectorA.z * vectorB.z);

        return dot;
    }

    float findAngle(float dot, float mag1, float mag2)
    {

        double angle = (Mathf.Acos(dot)/ (mag1 * mag2)) * Mathf.Rad2Deg;
        return (float)angle;
        
    }

    float AngleToPlayer()
    {
        Vector3 captain = transform.position;

        Vector3 player = OtherPlayer.transform.position;
        Vector3 vectorForward = Vector3.forward;
        Vector3 vectorToPlayer = new Vector3(player.x - captain.x, player.y - captain.y, player.z - captain.z);
        float magForward = Magnitude(vectorForward);
        float magPlayer = Magnitude(vectorToPlayer);
        vectorForward = Normalise(vectorForward);
        vectorToPlayer = Normalise(vectorToPlayer);
        float dot = Dot(vectorForward, vectorToPlayer);

        float angle = findAngle(dot, magForward, magPlayer);

        // Steps to calculate the angle between the direction Captain is facing and 
        // the direction from Captain to Other
        // 1. A
        // 2. B
        // 3. Calculate the angle between the vectors from A and B
        //    3.1 Calculate the dot product between A and B
        //       3.1.1 Calculate the magnitude of the vector from Captain to Other (A)
        //       3.1.2 Normalise the vector from Captain to Other
        //       3.1.3 Calculate the dot product of the normalised vectors A and B
        //    3.2 From the dot product, calculate the actual angle between A and B
        //       3.2.1 Take the arc cosine (acos) of the dot product (because if 
        //             both vector are normalised, the dot product equals the cos
        //             of the angle between vectors A and B.
        //       3.2.2 The acos angle returned is in radians. We must convert to
        //             degrees.

        // A
        // Steps to draw the arrow that represents the vector from Captain to Other 
        // 1. Find the vector from Captain to Other
        //     1.1 Find the position of Captain (A -- from)
        //     1.2 Find the position of Other (B -- to)
        //     1.3 Calculate B-A to get the vector from A to B
        // 2. Draw the arrow to represent visually the vector AB
        //

        // Your code here

        // B
        // Steps to draw an arrow that represents which direction Captain is facing
        // 1. Find which vector to draw as an arrow
        //    1.1 The transform.forward vector of Captain
        // 2. Draw the arrow to represent visually the the transform.forward vector of Captain
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);

        // CALCULATING THE ANGLE

        // Your code here
        // ...

        // Your code here


        return (float)angle;
    }

    void Update()
    {
        if (IsCaptain)
        {




            float angle = AngleToPlayer();
            Debug.Log(angle);
            Vector3 cap = transform.position;
            Vector3 player = OtherPlayer.transform.position;
            Vector3 vectorDirection = new Vector3(player.x - cap.x, player.y - cap.y, player.z - cap.z);
            DebugExtension.DebugArrow(cap, vectorDirection, Color.red);
            
        }
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);
    }
}
