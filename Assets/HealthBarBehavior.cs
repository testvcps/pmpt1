using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{
    public float currenthealth;
   Vector3 loacalScale;
   private HealthDecrease healthDecrease;
   void Start(){
    loacalScale = transform.localScale;
   }
   void Update(){
    loacalScale.x = currenthealth;
    transform.localScale = loacalScale;
    //Debug.Log(currenthealth);
   }
   public void Health(float health){
        currenthealth = health;
   }
}
