using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyWords : MonoBehaviour
{
	private List<string> keywords;
	public List<string> GetKeywords{get{return keywords;}}

	private void Awake()
	{
		keywords = new List<string>();
		keywords.Add("scan");
		keywords.Add("checkForFirewall");
		keywords.Add("connect");
		keywords.Add("ls");
		keywords.Add("disconnect");
		keywords.Add("clear");
		keywords.Add("tjoep");
		keywords.Add("help");
		keywords.Add("python");
		keywords.Add("exit");
		keywords.Add("attackFirewall");
		keywords.Add("instantiateKeylogger");
		keywords.Add ("startKeylogger");
		keywords.Sort();
	}

	public void addKeyword(string keyword)
	{
		keywords.Add (keyword);
	}
}
