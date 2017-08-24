using System.Collections.Generic;
[System.Serializable]
public class DataValues
{
    private int hours, minutes, day, month, year;
    private float money, loadTime, longLoadTime;

	public int Hours{get{return hours;}set{hours = value;}}
	public int Minutes{get{return minutes;}set{minutes = value;}}
	public int Day{get{return day;}set{day = value;}}
	public int Month{get{return month;}set{month = value;}}
	public int Year{get{return year;}set{year = value;}}

    public float Money{get{return money;} set{money = value;}}
    public float LoadTime{get{return loadTime;} set{loadTime = value;}}
    public float LongLoadTime{get{return LongLoadTime;} set{longLoadTime = value;}}

	private List<SaveData> gameObjects;
	public List<SaveData> GameObjects{get{return gameObjects;} set{gameObjects = value;}}

	private List<string> keywords;
	public List<string> Keywords{get{return keywords;} set{keywords = value;}}
}
