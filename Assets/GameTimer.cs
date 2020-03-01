using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float startTime;
    public float elapsedTime;
    float prevElapsed;

    public AudioSource title;
    public AudioSource music;
    public AudioSource gameoverSound;

    public Text timer;

    public PlayerSpawner playerSpawner;

    // Start is called before the first frame update
    void Start()
    {
        this.ResetTime();
        this.playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
        this.title.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSpawner.isZenMode)
        {
            this.timer.text = "Zen mode";
            return;
        }

        this.elapsedTime = Time.time - this.startTime;

        if (this.elapsedTime - prevElapsed > 1.0f)
        {
            this.timer.text = "Time: " + Mathf.Floor(this.elapsedTime) + "s";
            prevElapsed = this.elapsedTime;
        }
    }

    public void ResetTime()
    {
        this.prevElapsed = 0;
        this.startTime = Time.time;
        this.elapsedTime = 0;
    }

    public void PlayGameoverSound()
    {
        music.Stop();
        gameoverSound.Play();
        title.Play();
    }
}
