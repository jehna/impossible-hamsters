using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class NBitPixelize : MonoBehaviour {

	public int numberOfPixels = 128;
	public int colorBits = 8;
	private Material material;
	public Shader shader;

	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material(shader);
	}

	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		float screenw = Screen.width;
		float screenh = Screen.height;
		material.SetFloat("pixelRatio", screenh / screenw);
		material.SetFloat("pixelRound", numberOfPixels);
		material.SetFloat("colorRound",  Mathf.Pow(2.0f,colorBits/3.0f) - 1.0f);
		Graphics.Blit (source, destination, material);
	}
}
