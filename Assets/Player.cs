using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            this.GetComponent<Rigidbody>().velocity = Vector3.left * speed;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            this.GetComponent<Rigidbody>().velocity = Vector3.right * speed;
        }
    }
}
