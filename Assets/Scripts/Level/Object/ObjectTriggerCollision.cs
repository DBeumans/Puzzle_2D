using UnityEngine;

public class ObjectTriggerCollision : MonoBehaviour
{

    [SerializeField]private bool canPlaceObject = false;

    public bool GetCanPlaceObject { get { return canPlaceObject; } set { canPlaceObject = value; } }

    private void Start()
    {
        if (this.gameObject.name == "Object-Preview")
            canPlaceObject = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        canPlaceObject = false;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canPlaceObject = true;
        
    }
}
