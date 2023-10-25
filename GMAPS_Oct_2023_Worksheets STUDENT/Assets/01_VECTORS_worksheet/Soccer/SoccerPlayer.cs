using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Unity.VisualScripting.FullSerializer;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();
    }

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

    //SoccerPlayer FindClosestPlayerDot()
    //{
    //    SoccerPlayer closest = null;

    //    return closest;
    //}

    void DrawVectors()
    {
        if (IsCaptain)
        {
            foreach (SoccerPlayer other in OtherPlayers)
            {
                Vector3 dir = new Vector3(other.transform.position.x - transform.position.x, other.transform.position.y - transform.position.y,
                    other.transform.position.z - transform.position.z);
                Debug.DrawRay(transform.position, dir, Color.black);

            }
        }
        
    }

    void Update()
    {
        DrawVectors();
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
        }
    }
}


