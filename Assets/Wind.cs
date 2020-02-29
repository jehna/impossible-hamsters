using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wind : MonoBehaviour
{
    public float direction = -1;
    float elapsedSinceChange = 0;

    public float windChangeScale = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.elapsedSinceChange += Time.deltaTime;

        this.direction = (Mathf.PerlinNoise(Time.time * windChangeScale, 0) * 2) - 1;

        string text = "";

        if (direction < 0) {
            text = "<" + direction;
        } else {
            text = ">" + direction;
        }

        this.GetComponent<Text>().text = text;

        
    }
}
