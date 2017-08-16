using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class AutoComplete : MonoBehaviour
{
	private KeyWords keywords;

    [SerializeField]private ShowOutput output;
    [SerializeField]private InputField inputField;

    private void Start()
	{
		keywords = this.GetComponent<KeyWords>();
        output = this.GetComponent<ShowOutput>();
	}

    private List<string> scan (string value) 
	{
		if (string.IsNullOrEmpty(value)) 
			return null;
	
		List<string> found = keywords.Keywords.FindAll(word => word.StartsWith(value));
		if (found.Count == 0)
			return null;
		return found;
	}

    public void complete()
    {
        List<string> value = scan (inputField.text);
        if (value == null)
            return;

        if (value.Count == 1)
            inputField.text = value [0];
        else
        {
            output.addText ("Multiple possibilities for your input:",false);
            foreach (string word in value)
                output.addText (word, false);
        }
    }
} 