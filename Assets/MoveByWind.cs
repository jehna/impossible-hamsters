using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByWind : MonoBehaviour
{
    private Wind wind;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        wind = FindObjectOfType<Wind>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * wind.direction * speed);
    }
}
