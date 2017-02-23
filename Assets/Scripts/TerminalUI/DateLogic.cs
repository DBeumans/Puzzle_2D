using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class DateLogic : MonoBehaviour 
{
	public Text timeText;
	private int hours, minutes, day, month, year;

	private void Start()
	{
		hours = DateTime.Now.Hour;
		minutes = DateTime.Now.Minute;

		day = DateTime.Now.Day;
		month = DateTime.Now.Month;
		year = DateTime.Now.Year;
		updateText ();
		StartCoroutine (time());
	}

	private IEnumerator time()
	{
		while (true)
		{
			yield return new WaitForSeconds (1f);
			minutes++;

			if (minutes >= 60)
			{
				minutes = 0;
				hours++;
			}

			if (hours > 23)
			{
				hours = 0;
				day++;
			}

			if (day >= 30)
			{
				day = 1;
				month++;
			}
			if (month > 12)
			{
				month = 1;
				year++;
			}
			updateText ();
		}
	}

	private void updateText()
	{
		timeText.text = day.ToString("D2") + "/" + month.ToString("D2") + "/" + year.ToString("D2") + " - " + hours.ToString("D2") + ":" + minutes.ToString("D2");
	}
}

