using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegatProjectile : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    public GameObject shooter;

    private void Start()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x,transform.position.y);
        Vector2 newPosition = currentPosition + velocity * Time.deltaTime;

        RaycastHit2D[] hit = Physics2D.LinecastAll(currentPosition, newPosition);

        foreach (RaycastHit2D raycastHit2D in hit)
        {
            Debug.Log(raycastHit2D.collider.gameObject);
        }
        
        transform.position = newPosition;
    }

    public void setVelocity(Vector2 vector2)
    {
        velocity = vector2;
    }
}
