using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BikeMovement : MonoBehaviour
{
    [SerializeField] Transform bikeTransform;
    [SerializeField] float velocity;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bulletInstantiateScript bis;
    private Vector3 speed = Vector3.zero;
    private int count;



    private void Start()
    {
        speed.x = velocity*(-1);
        count = 0;
    }

    void Update()
    {
        if (Input.inputString != "")
        {
            switch (Input.inputString)
            {
                case "w":
                    bikeTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                    break;
                case "a":
                    bikeTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
                case "s":
                    bikeTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    break;
                case "d":
                    bikeTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                    break;
                default:
                    break;
            }
        }


    }

    private void FixedUpdate()
    {
        bikeTransform.Translate(speed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.compareScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyTrail"))
        {
            gameManager.enemyScoreUpdate(5);
            count++;
            if (count >= 10)
            {
                gameManager.compareScore();
            }
        }
        if (collision.gameObject.CompareTag("Border"))
        {
            gameManager.redWon();
        }
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
            speed.x = speed.x - 3;
            bis.increaseBullet();
        }
    }
    
}
