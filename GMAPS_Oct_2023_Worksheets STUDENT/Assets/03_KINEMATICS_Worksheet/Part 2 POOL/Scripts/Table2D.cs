using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table2D : MonoBehaviour
{
    public List<Ball2D> balls;

    private void Start()
    {

    }

    bool CheckBallCollision(Ball2D toCheck)
    {
        for (int i = 0; i < balls.Count; i++)
        {
            Ball2D ball = balls[i];

            if (ball.IsCollidingWith(toCheck) && toCheck != ball)
            {
                HVector2D v = new HVector2D(ball.transform.position - toCheck.transform.position);
                ball.Velocity = v * 10;
                return true;
            }
        }

        return false;
    }

    private void FixedUpdate()
    {
        if (CheckBallCollision(balls[0]))
        {
            Debug.Log("COLLISION!");
        }
    }
}
