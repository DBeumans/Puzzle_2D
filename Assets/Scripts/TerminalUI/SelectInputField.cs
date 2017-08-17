using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectInputField : MonoBehaviour 
{
    private InputField field;
    private EventSystem system;

    private ScanCommand scan;
    private ConnectCommand connect;
    private DisconnectCommand disconnect;

    private void Awake()
    {
        field = this.GetComponent<InputField>();
        system = GameObject.FindGameObjectWithTag(Tags.eventSystem).GetComponent<EventSystem>();

        scan = this.GetComponentInParent<ScanCommand>();
        scan.OnDone += selectField;

        connect = this.GetComponentInParent<ConnectCommand>();
        connect.OnDone += selectField;

        disconnect = this.GetComponentInParent<DisconnectCommand>();
        disconnect.OnDone += selectField;
    }

    public void selectField()
    {
        field.enabled = true;
        system.SetSelectedGameObject(field.gameObject, null);
        field.OnPointerClick(new PointerEventData(EventSystem.current));
    }
}
