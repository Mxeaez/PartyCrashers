﻿using UnityEngine;
using System.Collections;

public class LightChangeDancefloor : MonoBehaviour {

	[SerializeField]
	private Light lt;
	[SerializeField]
	private Color ColorZero;
	[SerializeField]
	private Color ColorOne;
	[SerializeField]
	private Color ColorTwo;
	[SerializeField]
	private Color ColorThree;
	[SerializeField]
	private Color ColorFour;
	[SerializeField]
	private Color ColorFive;
	[SerializeField]
	private Color ColorSix;
	[SerializeField]
	private Color ColorSeven;
	[SerializeField]
	private float colorSwapTime;

	[SerializeField]
	private float stoptime = 1;

	private Color CurrentColor;
	private int CurrentColorInt;
	private Color PreviousColor;
	private int PreviousColorInt;
	public int CurrentColorNumber;

	private bool stop = false;


	// Use this for initialization
	void Start()
	{		
		CurrentColorNumber = 1;
		lt = GetComponent<Light>();
		//changeColor();
	}

	// Update is called once per frame
	void Update()
	{
		if (stop == true) 
		{
			StartCoroutine (Stopedfor (stoptime));
		}
		else if (stop == false) 
		{
			StartCoroutine(Stopfor(stoptime));
			ColorRandomiser ();
		}
		lt.color = Color.Lerp (CurrentColor, PreviousColor, Mathf.PingPong (Time.time, 1));
		//For future reference, to make it only go one direction you will need to raise the variable ie.
		// lt.color = Color.Lerp(CurrentColor, PreviousColor,  "0.1 value raised by x until 1");
	}

	/*void changeColor()
	{
		if (CurrentColorNumber == 1)
		{
			CurrentColorNumber = 2;
		}
		else if  (CurrentColorNumber == 2)
		{
			CurrentColorNumber = 1;
		}
		Invoke("changeColor", colorSwapTime);
	}*/

	IEnumerator Stopfor(float wait) 
	{
		//this is the amount of time i want it to wait
		yield return new WaitForSeconds(wait);
		//this is what it will do when the timehas passed
		stop=true;
	} 

	IEnumerator Stopedfor(float wait) 
	{
		//this is the amount of time i want it to wait
		yield return new WaitForSeconds(wait);
		//this is what it will do when the timehas passed
		stop=false;

	} 

	void ColorRandomiser()
	{
		CurrentColorInt = Random.Range (0,7);
		PreviousColorInt = Random.Range (0,7);
		if (CurrentColorInt == PreviousColorInt) {
			ColorRandomiser ();
		} 
		else//im so sorry
		{
			if (CurrentColorInt == 0)
			{
				CurrentColor = ColorZero;
			}		
			else if (CurrentColorInt == 1) 
			{
				CurrentColor = ColorOne;
			}
			else if (CurrentColorInt == 2) 
			{
				CurrentColor = ColorTwo;
			}
			else if (CurrentColorInt == 3)
			{
				CurrentColor = ColorThree;
			}
			else if (CurrentColorInt == 4) 
			{
				CurrentColor = ColorFour;
			}
			else if (CurrentColorInt == 5) 
			{
				CurrentColor = ColorFive;
			}
			else if (CurrentColorInt == 6) 
			{
				CurrentColor = ColorSix;
			}
			else if (CurrentColorInt == 7) 
			{
				CurrentColor = ColorSeven;
			}

			if (PreviousColorInt == 0)
			{
				CurrentColor = ColorZero;
			}		
			else if (PreviousColorInt == 1) 
			{
				CurrentColor = ColorOne;
			}
			else if (PreviousColorInt == 2) 
			{
				CurrentColor = ColorTwo;
			}
			else if (PreviousColorInt == 3)
			{
				CurrentColor = ColorThree;
			}
			else if (PreviousColorInt == 4) 
			{
				CurrentColor = ColorFour;
			}
			else if (PreviousColorInt == 5) 
			{
				CurrentColor = ColorFive;
			}
			else if (PreviousColorInt == 6) 
			{
				CurrentColor = ColorSix;
			}
			else if (PreviousColorInt == 7) 
			{
				CurrentColor = ColorSeven;
			}
		}
			
	}
}
