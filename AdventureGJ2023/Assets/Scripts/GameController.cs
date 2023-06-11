using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    private static float health = 6;
    private static int maxHealth = 6;
    private static float moveSpeed = 5;
    private static float fireRate = 0.5f;
    private static float bulletSize = 0.5f;

    private bool bootCollected = false;
    private bool screwCollected = false;

    public List<string> collectedNames = new List<string>();
    public static float Health { get => health; set => health =value; }
    public static int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public static float FireRate { get => fireRate; set => fireRate = value; }
    public static float BulletSize { get => bulletSize; set => bulletSize = value; }

    private static TMP_Text HealthText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        HealthText = GameObject.Find("HealthText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Health: " + health; 
    }


    public static void DamagePlayer(int damage) 
    {
        health -= damage;

        if (Health <= 0)
        {
            KillPlayer();
        }
    }

    public static void HealPlayer(float healAmount)
    {
        health = Mathf.Min(maxHealth,health + healAmount);

    }

    private static void KillPlayer() 
    { 
    
    }
    public static void FireRateChange(float rate)
    {
        fireRate -= rate;
    }

    public static void BulletSizeChange(float size)
    {
        bulletSize += size;
    }

    
    public static void MoveSpeedChange(float speed)
    {
        moveSpeed += speed;
    }
    
    public void UpdateCollectedItems(ItemController item)
    {
        collectedNames.Add(item.item.name);

        //foreach (string i in collectedNames)
        //{
        //    switch (i)
        //    {
        //        case "Boot":
        //            bootCollected = true;
        //            break;
        //        case "Screw":
        //            screwCollected = true;
        //            break;
        //    }
        //}

        //if (bootCollected && screwCollected)
        //{
        //    FireRateChange(0.25f);
        //}
    }
}
