using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; //vi tri x y z cua player nho keo tha obj p vao T

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        //camera se ko bi xoay khi nvat bi xoay nua
    }
}
