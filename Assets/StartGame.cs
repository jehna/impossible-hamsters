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
        if (Input.GetKeyDown(KeyCode.Space) && !isGameOverPanelEnabled)
        {
            GetComponent<Image>().enabled = false;
            Time.timeScale = 1;
        }
    }
}
