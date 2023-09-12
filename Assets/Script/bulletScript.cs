using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed;
    [SerializeField] Transform bullet;
    private Vector2 worldSpaceDirection = Vector2.zero;
        
    private void Start()
    {
        worldSpaceDirection = bullet.TransformDirection(Vector2.left);
    }

    private void FixedUpdate()
    {
        rb.velocity = worldSpaceDirection * bulletSpeed;
    }
}
