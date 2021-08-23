/*
 * 
 *	Class for setup the camera and take photo in AR Game.
 * 
 */

using UnityEngine;
using UnityEngine.UI;

public class Capture : MonoBehaviour
{
	[SerializeField] private RawImage background;
	[SerializeField] private AspectRatioFitter fit;
	[SerializeField] private Renderer m_Display;

	ColorDetection csColorDetection;
	ButtonHandler csButtonHandler;

	private WebCamTexture cameraTexture;
	private Texture defaultBackground;

	private bool camAvailable;
	private bool frontFacing;

	// Using this for initialization
	void Start()
	{
		GetComponents();
		SetCamera();		
	}

	void Update()
	{
		if (!camAvailable)
        {
			return;
		}

		// Set the aspect ratio
		float ratio = (float)cameraTexture.width / (float)cameraTexture.height;
		fit.aspectRatio = ratio; 

		// Find if the camera is mirrored or not
		float scaleY = cameraTexture.videoVerticallyMirrored ? -1f : 1f;

		// Swap the mirrored camera
		background.rectTransform.localScale = new Vector3(1f, scaleY, 1f); 

		int orient = -cameraTexture.videoRotationAngle;
		background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}

	private void OnPostRender()
	{
		if (csButtonHandler.isCaptured)
		{
			m_Display.material.mainTexture = background.texture;
			Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
			texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
			texture.Apply();
			csColorDetection.GetAverage(texture);
			csButtonHandler.isCaptured = false;
			Destroy(texture);
		}
	}

	private void SetCamera()
    {
		defaultBackground = background.texture;
		WebCamDevice[] devices = WebCamTexture.devices;

		if (devices.Length == 0)
		{
			return;
		}
		for (int i = 0; i < devices.Length; i++)
		{
			var curr = devices[i];

			if (curr.isFrontFacing == frontFacing)
			{
				cameraTexture = new WebCamTexture(curr.name, Screen.width, Screen.height);
				break;
			}
		}

		if (cameraTexture == null)
		{
			return;
		}

		// Start the camera, set the texture and set camAvailable for future purposes.
		cameraTexture.Play();
		background.texture = cameraTexture;
		camAvailable = true;
	}

	private void GetComponents()
    {
		csButtonHandler = GameObject.Find("Canvas").GetComponent<ButtonHandler>();
		csColorDetection = GameObject.Find("Scene Manager").GetComponent<ColorDetection>();
    }
}