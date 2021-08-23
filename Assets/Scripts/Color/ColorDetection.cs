/*
 * 
 * The class in which RGB value determination by reading pixels and assigning to the closest color in the AR game.
 * 
 */

using UnityEngine;
using System;

public class ColorDetection : MonoBehaviour
{
	#region Colors

	readonly public string[] colors = new string[42] {
		"Red", "Red", "Red", "Red",
		"Blue", "Blue", "Blue","Blue","Blue","Blue","Blue","Blue",
		"Green","Green","Green","Green","Green","Green","Green","Green","Green","Green","Green","Green",
		"Orange","Orange","Orange",
		"Yellow","Yellow","Yellow",
		"Purple","Purple","Purple","Purple",
		"Pink", "Pink",
		"Black",
		"White",
		"Brown", "Brown",
		"Gray", "Gray"};

	readonly int[] rValues = new int[42] { 220, 178, 255, 139, 0, 30, 100, 65, 0, 0, 0, 25, 124, 127, 50, 0, 34, 0, 0, 0, 0,
		152, 60, 46, 255, 255, 255, 255, 255, 255, 138, 148, 75, 128, 255, 255, 0, 255, 139, 160, 128, 105 };
	readonly int[] gValues = new int[42] { 20, 34, 0, 0, 191, 144, 149, 105, 0, 0, 0, 25, 252, 255, 205, 255, 139, 128, 100,
		255, 250, 251, 179, 139, 165, 140, 69, 255, 255, 255, 43, 0, 0, 0, 105, 20, 0, 255, 69, 82, 128, 105 };
	readonly int[] bValues = new int[42] { 60, 34, 0, 0, 255, 255, 237, 225, 255, 205, 139, 112, 0, 0, 50, 0, 34, 0, 0, 127, 154,
		152, 113, 87, 0, 0, 0, 102, 51, 0, 226, 211, 130, 128, 180, 147, 0, 255, 19, 45, 128, 105 };

	#endregion Colors

	[SerializeField] private AudioSource asSounds;
	[SerializeField] private AudioClip[] acSounds;

	Sound csSound;
	HoldTheDoor csHoldTheDoor;

	public GameObject goCaptureButton;

    private int colorIndex = 0;
	private bool isFirst = true;
	private const int totalPixel = 21037;

	void Start()
    {
		GetComponents();
		PlaySound();
	}

	public void GetAverage(Texture2D texture)
	{
		// Read pixels and gets average RGB value

		int r, g, b;
		int totalR = 0;
		int totalG = 0;
		int totalB = 0;

		for (int w = 864; w <= 1056; w++)
		{
			for (int h = 486; h <= 594; h++) 
			{
				totalR = totalR + Convert.ToInt32(texture.GetPixel(w, h).r * 255);
				totalG = totalG + Convert.ToInt32(texture.GetPixel(w, h).g * 255);
				totalB = totalB + Convert.ToInt32(texture.GetPixel(w, h).b * 255);
			}
		}

		r = totalR / totalPixel;
		g = totalG / totalPixel;
		b = totalB / totalPixel;

		ColorSelector(r, g, b);
		Destroy(texture);
	}

	private void ColorSelector(int r, int g, int b)
	{
		// Selects closest color by RGB values

		int closestDistance = 200000;

		for (int i = 0; i < 42; i++)
		{
			int rSqrt = Square(rValues[i] - r);
			int gSqrt = Square(gValues[i] - g);
			int bSqrt = Square(bValues[i] - b);

			int distance = rSqrt + gSqrt + bSqrt;

			if (distance < closestDistance)
			{
				closestDistance = distance;
				colorIndex = i;
			}
		}

		PlaySound();
	}

	private int Square(int x)
	{
		return x * x;
	}

	private void PlaySound()
	{
		if (!isFirst)
		{
			asSounds.Stop();

			if (!csHoldTheDoor.muteNarrator)
            {
				asSounds.PlayOneShot(acSounds[colorIndex]);
			}	
		}
		else
		{
			csSound.PlaySoundWithDelay(acSounds[42], "AR");
			isFirst = false;
		}
	}

	private void GetComponents()
    {
		csSound = GameObject.Find("Scene Manager").GetComponent<Sound>();
		csHoldTheDoor = GameObject.Find("Door").GetComponent<HoldTheDoor>();
	}
}
