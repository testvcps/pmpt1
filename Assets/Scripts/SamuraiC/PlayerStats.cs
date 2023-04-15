using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int SetMaxHealth = 100;
    public int CurrentHealth;
    public HealthBar healthBar;     
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = SetMaxHealth;
        healthBar.SetMaxHealth(SetMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            TakeDmg(20);
        }
    }
    void  TakeDmg(int takedmg){
        CurrentHealth -=takedmg;
        healthBar.SetHealth(CurrentHealth);
    }
}
