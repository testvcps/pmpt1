using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    private int Oranges = 0;
    // [SerializeField] private Text cherriesText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruits"))
        {
            Destroy(collision.gameObject);
            Oranges++;
            // cherriesText.text = "Oranges: "+Oranges;
        }
    }
}