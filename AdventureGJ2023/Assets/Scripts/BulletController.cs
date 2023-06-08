using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float lifeTime;
    public bool isEnemyBullet = false;
    public float speed;
    private Vector2 lastPos, currPos, playerPos;
    void Start()
    {
        StartCoroutine(DeathDelay());
        if (!isEnemyBullet)
        {
             transform.localScale = new Vector2(GameController.BulletSize, GameController.BulletSize);
        }
       
    }

     void Update()
    {
        if (isEnemyBullet)
        {
            currPos = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
            if (currPos == lastPos)
            {
                Destroy(gameObject);
            }
            lastPos = currPos;
        }
    }

    public void GetPlayer(Transform player)
    {
        playerPos = player.position;
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy" && !isEnemyBullet)
        {
            col.gameObject.GetComponent<EnemyController>().Death();
            Destroy(gameObject);
           // Debug.Log("DIE");
        }

        if (col.tag == "Player" && isEnemyBullet)
        {
            GameController.DamagePlayer(1);
            Destroy(gameObject);
        }
    }
}
