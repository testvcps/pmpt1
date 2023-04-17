using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDecrease : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthBar healthBar;
    [SerializeField] public float ArcherH = 300f;
    public float currentHealth;
    [SerializeField] public float CommanderH = 300f;
    public float MaximumHealth = 300f;
    public Animator anim;
    public bool die;
    private float healthnow = 300f;
    void Start()
    {
        anim = GetComponent<Animator>();
        //healthBar = GetComponent<HealthBar>();
        // healthBar.SetMaxHealth(MaximumHealth);
        currentHealth = MaximumHealth;
        DisableAllText();
    }

    // Update is called once per frame
    void Update()
    {
      EnableText();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "Catk1" || collision.tag == "Catk2" ||collision.tag == "Catk3"||collision.tag == "Aatk1" ||collision.tag == "Aatk2"||collision.tag == "Aatk3"||collision.tag == "Aarrow")
            {
                anim.SetTrigger("hurt");
            }
            // else if (collision.gameObject.CompareTag("Commander"))
            // {
            //     healthBar.SetMaxHealth(CommanderH);
            // }
         if (collision.tag == "Catk1"){
            healthBar.TakeDamage(25);
            healthnow-=25;
            DeadChecker(healthnow);
            if (die==true){
               condition =2;
            }
            Debug.Log("-25");
         }
         else if (collision.tag == "Catk2"){
            healthBar.TakeDamage(35);
            healthnow-=35;
            DeadChecker(healthnow);
            if (die==true){
               condition =2;
            }
            Debug.Log("-35");
         }
         else if (collision.tag == "Catk3"){
            healthBar.TakeDamage(50);
            healthnow-=50;
            DeadChecker(healthnow);
            if (die==true){
               condition =2;
            }
            Debug.Log("-50");
         }
         else if (collision.tag == "Aatk1"){
            healthBar.TakeDamage(15);
            healthnow-=15;
            DeadChecker(healthnow);
            if (die==true){
               condition =1;
            }
            Debug.Log("-15");
         }
         else if (collision.tag == "Aatk2"){
            healthBar.TakeDamage(23);
            healthnow-=23;
            DeadChecker(healthnow);
            if (die==true){
               condition =1;
            }
            Debug.Log("-23");
         }
         else if (collision.tag == "Aatk3"){
            healthBar.TakeDamage(35);
            healthnow-=35;
            DeadChecker(healthnow);
            if (die==true){
               condition =1;
            }
            Debug.Log("-35");
         }
         else if (collision.tag == "Aarrow"){
            healthBar.TakeDamage(70);
            healthnow-=70;
            DeadChecker(healthnow);
            if (die==true){
               condition =1;
            }
            Debug.Log("-70"+ condition);
         }
    }
    void TakeDamage(int dmg){
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
    }

    void DeadChecker(float health){

        if(healthnow<=0)
        {
            die = true;
            anim.SetTrigger("die");
        }
    }
   public Text ArcherWin;  //Add reference to UI Text here via the inspector
   public Text CommanderWin;

   private float timeToAppear = 2f;
   private float timeWhenDisappear = 2f;
   
   private int condition = 0;
//Call to enable the text, which also sets the timer
   public void EnableText()
   { 
      if(condition == 1){
         ArcherWin.enabled = true;
         timeWhenDisappear = Time.time + timeToAppear;
      }
      if(condition == 2){
         CommanderWin.enabled = true;
         timeWhenDisappear = Time.time + timeToAppear;
      }
   }
   public void DisableAllText(){
      ArcherWin.enabled = false;
      CommanderWin.enabled = false;
   }
}
