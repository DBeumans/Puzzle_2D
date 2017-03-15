using UnityEngine;

public class Transfer : MonoBehaviour 
{
	public string transferMoney(string amount, string bankAccount, string code)
	{
		print ("get: $" + amount);
		print ("from: " + bankAccount);
		print ("with code: " + code);

		return "done";
	}
}
