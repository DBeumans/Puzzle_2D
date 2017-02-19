using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetFollower : MonoBehaviour {

    [SerializeField]GameObject target;
    [SerializeField]Vector3 offset;
    Vector3 velocity = Vector3.zero;
    [SerializeField]float smoothTime;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocity.y, smoothTime);
        transform.position = new Vector3(posX, posY,offset.z);
        //this.transform.position = offset + target.transform.position;
    }
}
