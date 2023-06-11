using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public string name, description;
    public Sprite itemImage;
}
public class ItemController : MonoBehaviour
{


    public Item item;
    public float healthChange, moveSpeedChange, attackSpeedChange, bulletSizeChange;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.itemImage;
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            GameController.HealPlayer(healthChange);
            GameController.MoveSpeedChange(moveSpeedChange);
            GameController.FireRateChange(attackSpeedChange);
            GameController.BulletSizeChange(bulletSizeChange);
            GameController.instance.UpdateCollectedItems(this);

            Destroy(gameObject);
        }
    }
}
