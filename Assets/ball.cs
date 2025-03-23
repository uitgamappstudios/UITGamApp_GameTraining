using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ball collided");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("ball is colliding");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("ball stopped colliding");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ball triggered");
    }
}
