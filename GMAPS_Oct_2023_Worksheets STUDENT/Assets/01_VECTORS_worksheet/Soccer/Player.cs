using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Player : MonoBehaviour
{
    public bool IsCaptain = true;
    public Player OtherPlayer;

    Vector3 captain;
    Vector3 player;

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

    float FindAngle(float dot)
    {

        double angle = (Mathf.Acos(dot)) * Mathf.Rad2Deg;
        return (float)angle;
        
    }

    float AngleToPlayer()
    {
        //get the position of the captain 
        captain = transform.position;

        //get the position of the player
        player = OtherPlayer.transform.position;

        // Calculate the forward vector of the captain
        Vector3 vectorForward = transform.forward;

        // Calculate the vector from the captain to the player (vector subtration)
        Vector3 vectorToPlayer = new Vector3(player.x - captain.x, player.y - captain.y, player.z - captain.z);

        // Visualize the vector from the captain to the player with a red arrow
        DebugExtension.DebugArrow(captain, vectorToPlayer, Color.red);

        // Normalize the vectors to ensure they have a length of 1
        vectorForward = Normalise(vectorForward); 
        vectorToPlayer = Normalise(vectorToPlayer);

        // Calculate the dot product between the forward vector and the vector to the player
        float dot = Dot(vectorForward, vectorToPlayer);

        // Calculate the angle between the two normalized vectors
        float angle = FindAngle(dot);

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
            
            
        }
       
    }
}
