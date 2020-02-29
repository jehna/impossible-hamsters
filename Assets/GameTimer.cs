using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float startTime;
    public float elapsedTime;
    float prevElapsed;

    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        this.ResetTime();
    }

    // Update is called once per frame
    void Update()
    {
        this.elapsedTime = Time.time - this.startTime;

        if (this.elapsedTime - prevElapsed > 1.0f) {
            this.timer.text = "Time: " + Mathf.Floor(this.elapsedTime);
            prevElapsed = this.elapsedTime;
        }
    }

    public void ResetTime() {
        this.prevElapsed = 0;
        this.startTime = Time.time;
        this.elapsedTime = 0;
    }
}
