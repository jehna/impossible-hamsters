using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public Player activePlayer;

    // Start is called before the first frame update
    void Start()
    {
        activePlayer = GameObject.FindObjectOfType<Player>();
        activePlayer.SetIsActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IList<Player> players = new List<Player>(GameObject.FindObjectsOfType<Player>().Where(p => p.selectable));

            if (players.Count == 0) {
                return;
            }

            int index = players.IndexOf(activePlayer);
            activePlayer.SetIsActive(false);

            if (index < players.Count - 1)
            {
                activePlayer = players[index + 1];
            } else
            {
                activePlayer = players[0];
            }

            activePlayer.SetIsActive(true);
        }
    }
}
