using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform PlayerPosition;
    private Vector2 offer;
    

    private void Start()
    {
        offer = transform.position - PlayerPosition.position;
    }

    private void LateUpdate()
    {
        if (PlayerPosition != null)
        {
            //transform.position = new Vector3(offer.x + PlayerPosition.position.x, offer.y + PlayerPosition.position.y, transform.position.z);
            transform.position = new Vector3(offer.x + PlayerPosition.position.x, PlayerPosition.position.y, transform.position.z);
        }

    }
}
