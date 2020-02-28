using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wind : MonoBehaviour
{
    public float direction = -1;
    float changeInterval = 8;
    float elapsedSinceChange = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ChangeDirection() {
        if (direction < 0) {
            direction = 1;
        } else {
            direction = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.elapsedSinceChange += Time.deltaTime;

        if (this.elapsedSinceChange > changeInterval) {
            ChangeDirection();
            this.elapsedSinceChange = 0;
        }

        string text = "";

        if (direction < 0) {
            text = "<";
        } else {
            text = ">";
        }

        this.GetComponent<Text>().text = text;
    }
}
