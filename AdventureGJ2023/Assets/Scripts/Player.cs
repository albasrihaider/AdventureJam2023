using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float fireDelay;
    private float lastFire;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //SV is shoot vertical and SH is shoot horizontal
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float SH = Input.GetAxis("SH");
        float SV = Input.GetAxis("SV");

        if((SH != 0 || SV != 0) && Time.time > lastFire + fireDelay)
        {
            Shoot(SH, SV);
            lastFire = Time.time;
        }

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0; 
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
                (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
                (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
                0
            );
    }
    
}
