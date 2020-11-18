using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class VelocityLimit : MonoBehaviour
{

    public float maxVelocity=50f;
    

     Rigidbody2D rigidBody2D;


    private void Awake() {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidBody2D.velocity = Vector2.ClampMagnitude(rigidBody2D.velocity,maxVelocity);
    }
}
