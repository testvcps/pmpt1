using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 loacalScale;
    Transform unit;
    Transform cam;
    void Start()
    {
        loacalScale = transform.localScale;
        unit = transform.parent;
        cam = GameObject.FindObjectOfType<Canvas>().transform;
        transform.SetParent(cam);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = loacalScale;
        transform.position = unit.position + loacalScale;
    }
}
