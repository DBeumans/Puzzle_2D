using System.Collections.Generic;
[System.Serializable]
public class DataValues
{
	private int hours, minutes, day, month, year;
	public int Hours{get{return hours;}set{hours = value;}}
	public int Minutes{get{return minutes;}set{minutes = value;}}
	public int Day{get{return day;}set{day = value;}}
	public int Month{get{return month;}set{month = value;}}
	public int Year{get{return year;}set{year = value;}}

	private List<SaveData> gameObjects;
	public List<SaveData> GameObjects{get{return gameObjects;} set{gameObjects = value;}}
}
