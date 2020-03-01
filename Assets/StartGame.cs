using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        GameObject.Find("NewHighscoreText").GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool isGameOverPanelEnabled = GameObject.Find("GameOverPanel").GetComponent<Image>().enabled;
        PlayerSpawner playerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();

        if (!isGameOverPanelEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerSpawner.isZenMode = false;
                GameStart();
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                playerSpawner.isZenMode = true;
                GameStart();
            }
        }
    }

    void GameStart()
    {
        if (Time.timeScale == 0) // we switch from start screen to playing
        {
            GameObject.FindObjectOfType<GameTimer>().title.Stop();
            GameObject.FindObjectOfType<GameTimer>().music.Play();
        }
        GetComponent<Image>().enabled = false;
        Time.timeScale = 1;
    }
}
