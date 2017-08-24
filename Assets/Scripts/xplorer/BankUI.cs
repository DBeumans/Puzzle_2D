using UnityEngine;
using UnityEngine.UI;

public class BankUI : MonoBehaviour 
{
	[Tooltip("The button to signin")]
	[SerializeField]private Button signinButton;

	[Tooltip("The feedback text object")]
	[SerializeField]private Text feedback;

	[Tooltip("The username and password field")]
	[SerializeField]private InputField[] inputFields;

	[SerializeField]private Text spendings;

	[SerializeField]private InputField accountInformtion;

	[SerializeField]private GameObject[] panels;

	private BankLogic logic;

	private void Start()
	{
		logic = GetComponent<BankLogic> ();
		signinButton.onClick.AddListener (delegate(){feedback.text = logic.signIn(inputFields[0].text, inputFields[1].text);});
	}

	public void showPanel(int index, bool value)
	{
		panels [index].SetActive (value);
	}

	public void showContents(string name, string user, string bank, float money, string code)
	{
		accountInformtion.text = "Company name: "+name+"\nCard name: " +user+"\nBank name: "+bank+"\nBalance: $"+money+"\nTransfer code: "+code;
		spendings.text = "Recent transactions:\n" + logic.companySpendings ();
	}
}
