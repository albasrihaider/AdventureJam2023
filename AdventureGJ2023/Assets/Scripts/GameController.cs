using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameController : MonoBehaviour
{

    public static GameController instance;

    private static int health = 10;
    private static int maxHealth = 10;
    private static float moveSpeed = 5;
    private static float fireRate = 0.5f;

    public static int Health { get => health; set => health =value; }
    public static int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public static float FireRate { get => fireRate; set => fireRate = value; }


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

    public static void HealPlayer(int healAmount)
    {
        health = Mathf.Min(maxHealth,health + healAmount);

    }

    private static void KillPlayer() 
    { 
    
    }
}
