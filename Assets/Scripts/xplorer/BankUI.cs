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

	[SerializeField]private Text accountInformtion;

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

	public void showContents()
	{
		accountInformtion.text = "Company name: "+ConnectToComputer.getUser.getName+"\nCard name: " + ConnectToComputer.getUser.Username+"\nBank name: "+ConnectToComputer.getUser.Bank+"\nBalance: $"+ConnectToComputer.getUser.Money;

	}
}
