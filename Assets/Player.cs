using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public float lift = 0.2f;
    public float unlift = 0.005f;
    public bool isActive = false;

    public SpringJoint springJoint;

    private Wind wind;

    // Start is called before the first frame update
    void Start()
    {
        wind = FindObjectOfType<Wind>();
    }

    // Update is called once per frame
    void Update()
    {
        this.springJoint.connectedAnchor += Vector3.down * unlift;

        if (isActive)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.GetComponent<Rigidbody>().velocity = Vector3.left * speed;
                if (wind.direction < 0)
                {
                    this.springJoint.connectedAnchor += Vector3.up * lift;
                }

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.GetComponent<Rigidbody>().velocity = Vector3.right * speed;
                if (wind.direction > 0)
                {
                    this.springJoint.connectedAnchor += Vector3.up * lift;
                }
            }
        }
    }
}
