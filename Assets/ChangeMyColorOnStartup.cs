using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMyColorOnStartup : MonoBehaviour
{
    
    public void ChangeMyColorTo(Color color)
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", color);
    }
}
