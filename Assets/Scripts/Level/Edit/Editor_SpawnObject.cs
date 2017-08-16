using UnityEngine;

public class Editor_SpawnObject : MonoBehaviour {

    private GameObject itemInHand;
    public GameObject GetItemInHand { get { return itemInHand; } set { itemInHand = value; } }
    private Inventory myInventory;
    private InventoryUI myInventoryUI;
    public InventoryUI GetMyInventoryUI { get { return myInventoryUI; } }
    public Inventory GetMyInventory { get { return myInventory; } }

    private InputBehaviour input;

    [SerializeField]private bool isPreviewing;
    private bool isPlaced;

	public bool GetIsPreviewing { get { return isPreviewing; } }
	public bool GetIsPlaced{ get { return isPlaced; } }

    [SerializeField]private Vector3 mousePos;

    private ObjectTriggerCollision objCollision;
    [SerializeField]private GameObject myParent;
    private string objName;
    public string GetObjName { get { return objName; } }

    private void Start()
    {
        input = GetComponent<InputBehaviour>();
        itemInHand = null;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

        myInventory = GetComponent<Inventory>();
        myInventoryUI = GetComponent<InventoryUI>();
    }

    public void PreviewObject(GameObject previewObj,string objName)
	{
        this.objName = objName;
        if (itemInHand != null)
        {
            Destroy(itemInHand);
            itemInHand = previewObj;
        }
        itemInHand = previewObj;
        
        GameObject obj = Instantiate(itemInHand, new Vector3(mousePos.x, mousePos.y, 0f), Quaternion.identity);
        itemInHand = obj;
        obj.GetComponent<Editor_ObjectMouseFollower>().GetFoll = true;
        obj.gameObject.name = "Object-Preview";
        isPreviewing = true;
        isPlaced = false;
    }

	public void PlaceObject(GameObject myObject,string ObjName)
	{
        objCollision = itemInHand.GetComponent<ObjectTriggerCollision>();
        if (!objCollision.GetCanPlaceObject)
        {
            print("Cant place object in a other object!");
            return;
        }
        else
        {
            GameObject obj = Instantiate(myObject);
            myObject.transform.position = new Vector3(mousePos.x, mousePos.y);
            obj.GetComponent<Editor_ObjectMouseFollower>().GetFoll = false;
            obj.gameObject.name = ObjName;
            this.objName = ObjName;
            obj.AddComponent<BoxCollider2D>();
            obj.GetComponent<ObjectSelect>().GetLastPos = obj.transform.position;
            obj.transform.SetParent(myParent.transform);
            Destroy(itemInHand);
            isPreviewing = false;
            isPlaced = true;
            itemInHand = null;

        }
    }
}
