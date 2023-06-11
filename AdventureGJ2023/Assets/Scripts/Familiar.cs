using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiar : MonoBehaviour
{

    private float lastFire;
    private GameObject player;
    public FamilarData familar;
    private float lastOffsetX, lastOffsetY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float SH = Input.GetAxis("SH");
        float SV = Input.GetAxis("SV");

        if ((SH != 0 || SV != 0) && Time.time > lastFire + familar.fireDelay)
        {
            Shoot(SH, SV);
            lastFire = Time.time;
        }

        if (horizontal != 0 || vertical != 0)
        {
            float offsetX = (horizontal < 0) ? Mathf.Floor(horizontal) : Mathf.Ceil(horizontal);
            float offsetY = (horizontal < 0) ? Mathf.Floor(vertical) : Mathf.Ceil(vertical);

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, familar.speed * Time.deltaTime);
            lastOffsetX = offsetX;
            lastOffsetY = offsetY;

        }
        else 
        {
            if (!(transform.position.x < lastOffsetX + 0.5f)|| !(transform.position.y < lastOffsetY + 0.5f))
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x - lastOffsetX, player.transform.position.y - lastOffsetY),familar.speed * Time.deltaTime);
            }
        }
    }

     void Shoot(float x, float y)
    {

        GameObject bullet = Instantiate(familar.bulletPrefab, transform.position, Quaternion.identity) as GameObject;
        float posX = (x < 0) ? Mathf.Floor(x) * familar.speed : Mathf.Ceil(x) * familar.speed;
        float posY = (y < 0) ? Mathf.Floor(y) * familar.speed : Mathf.Ceil(y) * familar.speed;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(posX, posY);
    }
}
