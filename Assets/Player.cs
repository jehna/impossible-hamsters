using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public float lift = 0.2f;
    public float unlift = 0.005f;
    private bool isActive = false;
    public float maxKiteHeight = 10.0f;
    public float windEffectOnKite = 5.0f;

    public SpringJoint springJoint;

    private Wind wind;

    // Start is called before the first frame update
    void Start()
    {
        wind = FindObjectOfType<Wind>();
    }

    public void SetIsActive(bool _isActive) {
        this.isActive = _isActive;
        this.GetComponent<MeshRenderer>().material.SetColor("_Color", this.isActive ? Color.magenta : Color.white);
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
                    this.springJoint.connectedAnchor = Vector3.up * Mathf.Min(lift + this.springJoint.connectedAnchor.y, this.maxKiteHeight);
                }

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.GetComponent<Rigidbody>().velocity = Vector3.right * speed;
                if (wind.direction > 0)
                {
                    this.springJoint.connectedAnchor = Vector3.up * Mathf.Min(lift + this.springJoint.connectedAnchor.y, this.maxKiteHeight);
                }
            }
        }

        this.springJoint.connectedAnchor = this.springJoint.connectedAnchor + new Vector3(-this.springJoint.connectedAnchor.x + wind.direction * windEffectOnKite, 0, 0);
    }
}
