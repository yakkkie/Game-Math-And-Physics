using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new Vector3( planet.position.x - rb.position.x, planet.position.y - rb.position.y);
        //gravityDir = -rb.position;

        moveDir = new Vector3(gravityDir.y, -gravityDir.x ,0);
        
        moveDir = moveDir.normalized * -1f ;
        

        rb.AddForce(moveDir * force);

        gravityNorm = gravityDir.normalized;

        rb.AddForce(gravityNorm * gravityStrength);

        float angle = Vector3.SignedAngle(Vector3.right, moveDir, Vector3.forward);

        Debug.Log("test\t" +angle);

        Vector3 rotate = new Vector3(0,0,angle);

        rb.MoveRotation(Quaternion.Euler(rotate));

        DebugExtension.DebugArrow(rb.position, moveDir, Color.blue);
        DebugExtension.DebugArrow(rb.position, gravityDir, Color.red);

    }
}


