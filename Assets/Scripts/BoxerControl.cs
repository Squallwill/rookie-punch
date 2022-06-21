using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerControl : MonoBehaviour
{
    public float speed = 15;
    public string axis;

    

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw(axis) * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(h, 0);
    }
}
