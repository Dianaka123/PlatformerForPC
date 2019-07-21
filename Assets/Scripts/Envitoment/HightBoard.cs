using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightBoard : MonoBehaviour
{
    [SerializeField] Transform Background;
    private void Start()
    {
        Vector2 newHight = new Vector2(GetComponent<BoxCollider2D>().size.x , Background.position.x * 2f);
        GetComponent<BoxCollider2D>().size = newHight;
    }
}
