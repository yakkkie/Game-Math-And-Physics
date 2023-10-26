using UnityEngine;
using System.Linq;
using System;
using Unity;
    


public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();

        if(IsCaptain)
        {
            FindMinimum();
        }
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

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;

        float minAngle = 180f;

        for (int i = 0; i < OtherPlayers.Length; i++)
        {
            Vector3 toPlayer = OtherPlayers[i].transform.position - transform.forward;
            toPlayer = Normalise(toPlayer);
            float dot = Dot(toPlayer, transform.forward);
            float angle = Mathf.Acos(dot);
            angle = angle * Mathf.Rad2Deg;

            if(angle < minAngle)
            {
                minAngle = angle;
                closest = OtherPlayers[i];
            }


        }


        return closest;
    }

    void DrawVectors()
    {
     
            foreach (SoccerPlayer other in OtherPlayers)
            {
                Vector3 dir = new Vector3(other.transform.position.x - transform.position.x, other.transform.position.y - transform.position.y,
                    other.transform.position.z - transform.position.z);
                Debug.DrawRay(transform.position, dir, Color.black);

            }
        
        
    }

    void Update()
    {
        DrawVectors();
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        if (IsCaptain)
        {
            DrawVectors();
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;

            foreach (SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
            
        }
    }

    void FindMinimum()
    {
        float lowestHeight = 0;
        for (int i = 0; i < 10; i++)
        {
            float height = UnityEngine.Random.Range(1f, 200f);
            Debug.Log(height);

            if (lowestHeight == 0)
            {
                lowestHeight = height;
            }
            if(height < lowestHeight)
            {
                lowestHeight = height;
            }


        }
        Debug.Log("The minimum height is "+ lowestHeight);
    }
}


