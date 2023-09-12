using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBikeMovement : MonoBehaviour
{
    [SerializeField] private Transform bikeTransform;
    [SerializeField] private float velocity;        
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bulletInstantiateScript bis;
    private Vector3 speed = Vector3.zero;
    private int count;

    


    private void Start()
    {
        speed.x = velocity*(-1);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            bikeTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            bikeTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            bikeTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            bikeTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
    }

    private void FixedUpdate()
    {
        bikeTransform.Translate(speed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.compareScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerTrail"))
        {
            gameManager.playerScoreUpdate(5);
            count++;
            if (count >= 10)
            {
                gameManager.compareScore();
            }
        }
        if (collision.gameObject.CompareTag("Border"))
        {
            gameManager.blueWon();
        }
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
            speed.x = speed.x - 3;
            bis.increaseBullet();
        } 
    }
}
