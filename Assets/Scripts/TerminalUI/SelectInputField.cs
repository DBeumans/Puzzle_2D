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
    private CheckFirewallCommand checkFirewall;
    private AttackFirewallCommand attackFirewall;
    private KeylogUploadCommand keylogUpload;
    private KeylogStartCommand keylogStart;
    private TransferCommand transfer;

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

        checkFirewall = this.GetComponentInParent<CheckFirewallCommand>();
        checkFirewall.OnDone += selectField;

        attackFirewall = this.GetComponentInParent<AttackFirewallCommand>();
        attackFirewall.OnDone += selectField;

        keylogUpload = this.GetComponentInParent<KeylogUploadCommand>();
        keylogUpload.OnDone += selectField;

        keylogStart = this.GetComponentInParent<KeylogStartCommand>();
        keylogStart.OnDone += selectField;

        transfer = this.GetComponentInParent<TransferCommand>();
        transfer.OnDone += selectField;
    }

    public void selectField()
    {
        field.enabled = true;
        system.SetSelectedGameObject(field.gameObject, null);
        field.OnPointerClick(new PointerEventData(EventSystem.current));
    }
}
