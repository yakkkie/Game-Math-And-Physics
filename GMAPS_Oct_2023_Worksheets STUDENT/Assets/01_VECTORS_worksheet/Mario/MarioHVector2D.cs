using Unity.VisualScripting;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private HVector2D up;
    private Rigidbody2D rb;
    float prevAngle = -Mathf.Infinity;
    float dot;
    float angle;
    HVector2D right;
    //float signedAngle;
    float t, timeStart = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        up = new(-Vector3.up);
        right = new (Vector3.right);
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);

        moveDir.Normalize();
        moveDir *= -1f;
        rb.AddForce(moveDir.ToUnityVector3() * force);

        gravityDir.Normalize();
        rb.AddForce(gravityDir.ToUnityVector3() * gravityStrength);

        angle = right.FindAngle(moveDir);

        //float signedAngle = gravityDir.SignedAngle(up, gravityDir);

        Debug.Log("Angle \t" + angle + "\nTime\t" + t);

        if (t < timeStart)
        {
            rb.MoveRotation(Quaternion.Euler(0, 0, -angle));
            t += Time.fixedDeltaTime;
        }
        else if (t >= timeStart)
        {
            if (angle > prevAngle)
            {
                rb.MoveRotation(Quaternion.Euler(0, 0, -angle));
            }
            else if (angle < prevAngle)
            {
                rb.MoveRotation(Quaternion.Euler(0, 0, angle));
            }
        
        }
        prevAngle = angle;
        //if (angle > prevAngle)
        //{
        //    rb.MoveRotation(Quaternion.Euler(0, 0, -angle));
        //}
        //else if (angle < prevAngle)
        //{
        //    rb.MoveRotation(Quaternion.Euler(0, 0, angle));
        //}
        //prevAngle = angle;


    }
}
