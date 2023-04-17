using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDecrease : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthBar healthBar;
    [SerializeField] public float ArcherH = 300f;
    public float currentHealth;
    [SerializeField] public float CommanderH = 300f;
    public float MaximumHealth = 300f;
    void Start()
    {
        //healthBar = GetComponent<HealthBar>();
        // healthBar.SetMaxHealth(MaximumHealth);
        // currentHealth = MaximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("o")){
            healthBar.TakeDamage(20);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.CompareTag("Archer"))
        // {
        //     healthBar.SetMaxHealth(ArcherH);
        // }
        // else if (collision.gameObject.CompareTag("Commander"))
        // {
        //     healthBar.SetMaxHealth(CommanderH);
        // }
        if (collision.tag == "Catk1"){
            healthBar.TakeDamage(25);
            Debug.Log("-25");
        }
        else if (collision.tag == "Catk2"){
            healthBar.TakeDamage(35);
            Debug.Log("-35");
        }
        else if (collision.tag == "Catk3"){
            healthBar.TakeDamage(50);
            Debug.Log("-50");
        }
        else if (collision.tag == "Aatk1"){
            healthBar.TakeDamage(15);
            Debug.Log("-15");
        }
        else if (collision.tag == "Aatk2"){
            healthBar.TakeDamage(23);
            Debug.Log("-23");
        }
        else if (collision.tag == "Aatk3"){
            healthBar.TakeDamage(35);
            Debug.Log("-35");
        }
        else if (collision.tag == "Aarrow"){
            healthBar.TakeDamage(70);
            Debug.Log("-70");
        }
    }
    void TakeDamage(int dmg){
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
    }
}
