using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Interactions : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("DEGATS");
            TakeDamage(20);
        }
    }

    void TakeDamage(float damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }



    void OnCollisionEnter(Collision collision){
        if (collision.collider.CompareTag("Player2")){
            Debug.Log("Player 1 : Aïe j'ai mal");
        }
    }
}
