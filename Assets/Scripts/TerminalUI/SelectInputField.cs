using UnityEngine;
using UnityEngine.UI;

public class SelectInputField : MonoBehaviour 
{
    private InputField field;
    private void Awake(){field = this.GetComponent<InputField>();}
    private void OnEnable(){field.Select();}
}
