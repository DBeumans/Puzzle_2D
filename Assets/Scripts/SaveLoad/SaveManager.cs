[System.Serializable]
public class SaveManager
{
	//Create a variable to store your level in
	private int level{ get; set;}
	//Make the variable accessible to get and set from other scripts	
	public int Level
	{
		get
		{
			return level;
		}
		set
		{
			level = value;
		}
	}
}