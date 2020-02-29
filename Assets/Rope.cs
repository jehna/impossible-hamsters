using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Transform player;
    public Transform kite;
    private LineRenderer line;
    // Start is called before the first frame update

    private int LINE_COUNT = 10;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = LINE_COUNT;
    }

    // Update is called once per frame
    void Update()
    {
        
        List<Vector3> points = new List<Vector3>();
        for(int i = 0; i <= LINE_COUNT - 1; i++)
        {
            float p = (float)i / (float)(LINE_COUNT - 1);
            Vector3 kneePos = Vector3.Lerp((player.position + kite.position) / 2, new Vector3(kite.position.x, 0, 0), 0.3f);

            points.Add(
                Vector3.Lerp(
                    Vector3.Lerp(player.position, kneePos, p),
                    Vector3.Lerp(kneePos, kite.position, p),
                    p
                )
           );
        }
        line.SetPositions(points.ToArray());
    }
}
