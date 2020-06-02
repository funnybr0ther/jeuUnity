using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LegatShooting : MonoBehaviour
{
    private KeyCode key = KeyCode.Mouse0;
    
    private float chargeTimer = 0;
    
    public GameObject projectile;
    public float maxChargeTimer = 2f;
    public float speed;

    private Camera cam;

    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key)) // Player started channelling the cast
        {
            chargeTimer = 0;
        }

        else if (Input.GetKey(key))
        {
            if (chargeTimer <= maxChargeTimer)
            {
                chargeTimer += Time.deltaTime;
            }
            else
            {
                Shoot(chargeTimer);
                chargeTimer = 0;
            }
        }
        else if (Input.GetKeyUp(key))
        {
            chargeTimer += Time.deltaTime;
            Shoot(chargeTimer);
        }
    }

    private void Shoot(float chargeTimer)
    {
        Debug.Log("SUPER!");
        GameObject sent = Instantiate(projectile,_rigidbody2D.position+Vector2.up*0.5f,Quaternion.identity);
        LegatProjectile legat = sent.GetComponent<LegatProjectile>();
        Vector3 _relativePos = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
        legat.setVelocity(new Vector2(_relativePos.x*chargeTimer*speed,_relativePos.y*chargeTimer*speed));
        
    }
}
