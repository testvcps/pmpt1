using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDecrease : MonoBehaviour
{
    // Start is called before the first frame update
    //public HealthBar healthBar;
    public HealthBarBehavior healthBar;
    public float ArcherH = 3f;
    public float CommanderH = 3.5f;
    public float AmountOfHealth;
    public Animator anim;
    public bool die;
    //private float healthnow;
    public Collider2D collision;
    void Start()
    {
        //healthBar = GetComponent<HealthBarBehavior>();
        anim = GetComponent<Animator>();
        if(collision.tag == "Commander"){
            AmountOfHealth = CommanderH;
            healthBar.currenthealth = AmountOfHealth;
        }
        else if (collision.tag == "Archer"){
            AmountOfHealth = ArcherH;
            healthBar.Health(AmountOfHealth);
            healthBar.currenthealth = AmountOfHealth;
        }
    }

    // Update is called once per frame
    void Update()
    
    {
         //healthBar.Health(AmountOfHealth);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag == "Catk1" || collision.tag == "Catk2" ||collision.tag == "Catk3"||collision.tag == "Aatk1" ||collision.tag == "Aatk2"||collision.tag == "Aatk3"||collision.tag == "Aarrow")
            {
                anim.SetTrigger("hurt");
            }
         if (collision.tag == "Catk1"){
            AmountOfHealth-=0.25f;
            //healthBar.Health(AmountOfHealth);
            DeadChecker(AmountOfHealth);
            Debug.Log("-25" + AmountOfHealth);
            healthBar.Health(AmountOfHealth);
         }
         else if (collision.tag == "Catk2"){
            AmountOfHealth-=0.35f;
            DeadChecker(AmountOfHealth);
            Debug.Log("-35 "+ AmountOfHealth);
            healthBar.Health(AmountOfHealth);
         }
         else if (collision.tag == "Catk3"){
            AmountOfHealth-=0.50f;
            DeadChecker(AmountOfHealth);
            Debug.Log("-50 "+ AmountOfHealth);
            healthBar.Health(AmountOfHealth);
         }
         else if (collision.tag == "Aatk1"){
            AmountOfHealth-=0.15f;
            DeadChecker(AmountOfHealth);
            Debug.Log("-15 "+ AmountOfHealth);
            healthBar.Health(AmountOfHealth);           
         }
         else if (collision.tag == "Aatk2"){
            AmountOfHealth-=0.23f;
            DeadChecker(AmountOfHealth);
            Debug.Log("-23 "+ AmountOfHealth);
            healthBar.Health(AmountOfHealth);
         }
         else if (collision.tag == "Aatk3"){
            AmountOfHealth-=0.35f;
            DeadChecker(AmountOfHealth);
            Debug.Log("-35 "+ AmountOfHealth);
            healthBar.Health(AmountOfHealth);
         }
         else if (collision.tag == "Aarrow"){
            AmountOfHealth-=0.70f;
            DeadChecker(AmountOfHealth);
            Debug.Log("-70 "+ AmountOfHealth);
            healthBar.Health(AmountOfHealth);
         }
    }
    void DeadChecker(float health){

        if(health<=0)
        {
            die = true;
            anim.SetTrigger("die");
        }
    }
    public void Destroy(){
      if (die==true){
         Destroy(gameObject);
      }
    }
}
