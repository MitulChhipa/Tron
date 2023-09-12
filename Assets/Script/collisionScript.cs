using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class collisionScript : MonoBehaviour
{
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private EdgeCollider2D ec;
    

    private void Update()
    {
        SetColliderPointsFromTrail(tr,ec);
    }

    public void SetColliderPointsFromTrail(TrailRenderer x,EdgeCollider2D y)
    {
        List<Vector2> points = new List<Vector2>();
        for(int i = 0; i < x.positionCount; i++)
        {
            points.Add(x.GetPosition(i));
        }
        y.SetPoints(points);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Blue Bullet") && gameObject.CompareTag("EnemyTrail"))|| (collision.gameObject.CompareTag("Red Bullet") && gameObject.CompareTag("PlayerTrail")))
        {
            Vector3 point = collision.contacts[0].point;
            contact(point, tr);
            Destroy(collision.gameObject);
        }
    }

    private void contact(Vector3 x,TrailRenderer y)
    {
        //print("Contact Called");
        int k = 0;
        bool xAxis=false;
        bool yAxis=false;
        float vd = 0.35f;
        for (int i = y.positionCount-1; i >=0 ; i--)
        {
            yAxis = (y.GetPosition(i).y-x.y< vd && y.GetPosition(i).y - x.y > 0) || (y.GetPosition(i).y - x.y >(-1)*vd && y.GetPosition(i).y - x.y <=0);
            xAxis = (y.GetPosition(i).x-x.x< vd && y.GetPosition(i).x - x.x > 0) || (y.GetPosition(i).x - x.x >(-1)*vd && y.GetPosition(i).x - x.x <=0);
            if (xAxis && yAxis)
            {
                k = i;
                if (k < y.positionCount-3)
                {
                    for (int j = 0; j <= k + 3; j++)
                    {
                        //setting points in trail
                        y.SetPosition(j, y.GetPosition(k + 3));
                    }
                }
                else
                {
                    for (int j = 0; j <y.positionCount; j++)
                    {
                        y.Clear();
                    }
                }
                return;
            }
        }
    }
}