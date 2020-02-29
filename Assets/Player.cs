﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public float lift = 0.2f;
    public float penaltyLift = 0.2f;
    public float unlift = 0.005f;
    private bool isActive = false;
    public float maxKiteHeight = 10.0f;
    public float windEffectOnKite = 5.0f;
    private Vector3 previousPosition;

    public SpringJoint springJoint;

    private Wind wind;

    // Start is called before the first frame update
    void Start()
    {
        wind = FindObjectOfType<Wind>();
        previousPosition = transform.position;
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
            float deltaX = this.GetComponent<Rigidbody>().velocity.x;

            if (deltaX < 0) {
                if (wind.direction > 0)
                {
                    this.springJoint.connectedAnchor = Vector3.up * Mathf.Min(lift + this.springJoint.connectedAnchor.y, this.maxKiteHeight);
                } 
                else 
                {
                    this.springJoint.connectedAnchor += Vector3.down * penaltyLift;
                }
            } else if (deltaX > 0) {
                if (wind.direction < 0)
                {
                    this.springJoint.connectedAnchor = Vector3.up * Mathf.Min(lift + this.springJoint.connectedAnchor.y, this.maxKiteHeight);
                }
                else 
                {
                    this.springJoint.connectedAnchor += Vector3.down * penaltyLift;
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            }
        }

        this.springJoint.connectedAnchor = this.springJoint.connectedAnchor + new Vector3(-this.springJoint.connectedAnchor.x + wind.direction * windEffectOnKite, 0, 0);
    }
}
