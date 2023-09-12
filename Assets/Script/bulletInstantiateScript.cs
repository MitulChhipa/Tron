using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bulletInstantiateScript : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] TextMeshProUGUI bulletCountScore;
    private int bulletCount = 10;

    private void Update()
    {
        if (((Input.GetKeyDown(KeyCode.Space)&&gameObject.CompareTag("Player"))|| (Input.GetKeyDown(KeyCode.RightControl) && gameObject.CompareTag("Enemy"))) && bulletCount>0)
        {
            bulletInstance();
        }
    }

    private void bulletInstance()
    {
        Instantiate(bullet, transform.position + new Vector3(-1f, 0, 0), transform.rotation);
        bulletCount--;
        bulletCountScore.text = bulletCount.ToString();
    }

    public void increaseBullet()
    {
        bulletCount = bulletCount+5;
        bulletCountScore.text = bulletCount.ToString();
    }
}
