using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Character
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    [SerializeField] private Transform bot;

    [SerializeField] private float speed;

    [SerializeField] private int direcction = 1;
    private bool isRight;
    private bool isAble = false;

    private void Update()
    {
        Vector2 target = currentMovementTarget();

        bot.position = Vector2.MoveTowards(bot.position, target, speed * Time.deltaTime);
        ChangeAnim("Run");

        float distance = Vector2.Distance(target, bot.position);

        if (distance <= 0.1f)
        {
            direcction *= -1;
        }

        //if (Vector3.Distance(bot.transform.position, startPoint.position) <= 0.1f)
        //{
        //    ChangeDirection(!isRight);
        //}
        //else if (Vector3.Distance(bot.transform.position, endPoint.position) <= 0.1f)
        //{
        //    ChangeDirection(!isRight);
        //}

        if (direcction <= - 1)
        {
            if (isAble == false)
            {
                ChangeDirection(!isRight);
                isAble = false;
            }
        }
    }

    private Vector2 currentMovementTarget()
    {
        if (direcction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (bot != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(bot.position, startPoint.position);
            Gizmos.DrawLine(bot.position, endPoint.position);
        }
    }

    public void ChangeDirection(bool isRight)
    {
        this.isRight = isRight;
        isAble = true;
        transform.rotation = isRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }
}
