using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectInputField : MonoBehaviour 
{
    private InputField field;
    private EventSystem system;
    private void Awake()
    {
        field = this.GetComponent<InputField>();
        system = GameObject.FindGameObjectWithTag(Tags.eventSystem).GetComponent<EventSystem>();
    }

    private void Update()
    {
        if (system.currentSelectedGameObject == field.gameObject)
            return;
        
        system.SetSelectedGameObject(field.gameObject, null);
        field.OnPointerClick(new PointerEventData(EventSystem.current));
    }
}
