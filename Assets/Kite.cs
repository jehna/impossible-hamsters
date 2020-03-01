using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kite : MonoBehaviour
{
    public Player player;
    public AudioSource[] hitSounds;

    // Start is called before the first frame update
    void Start()
    {
        hitSounds = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameOver();
        }

    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Ground") {
            GameOver();
        }
        if (collision.gameObject.GetComponent<Kite>() != null) {
            AudioSource hitSound = hitSounds[Random.Range(0, hitSounds.Length)];
            hitSound.Play();
        }
    }

    void GameOver()
    {
        GameObject.Find("GameOverPanel").GetComponent<Image>().enabled = true;
        Debug.Log("Hävisit pelin :(");
        Time.timeScale = 0;

        Text score = GameObject.Find("Timer").GetComponent<Text>();
        score.rectTransform.pivot = Vector3.one / 2;
        score.rectTransform.anchorMin = score.rectTransform.anchorMax = Vector2.one / 2;
        score.rectTransform.anchoredPosition = Vector3.down * 85.7f;
        score.alignment = TextAnchor.MiddleCenter;
        score.fontSize = 70;

        var elapsedTime = GameObject.FindObjectOfType<GameTimer>().elapsedTime;
        

        if (elapsedTime > Highscore.highestScore) {
            GameObject.Find("NewHighscoreText").GetComponent<Text>().enabled = true;
            Highscore.highestScore = elapsedTime;
            GameObject.FindObjectOfType<GameTimer>().PlayHappyGameoverSound();
        } else {
            GameObject.FindObjectOfType<GameTimer>().PlayGameoverSound();
        }
    }
}
