using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuskanHeiluttaja : MonoBehaviour
{
    float direction;
    private Wind wind;
     

    // Start is called before the first frame update
    void Start()
    {
        direction = this.transform.parent.localEulerAngles.y != 0 ? 1 : -1;
        float freq = Random.Range(4.0f, 6.0f);
        foreach (Material m in this.GetComponent<Renderer>().materials)
        {
            m.SetFloat("_WindMultiplier", direction * Random.Range(0.7f, 0.15f));
            m.SetFloat("_Frequency", freq);
        }

        wind = FindObjectOfType<Wind>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Material m in this.GetComponent<Renderer>().materials) m.SetFloat("_Wind", -wind.direction);
    }
}
