using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float moveRange = 15;
    private Vector3 ogirinalPosition;
    private GameObject obj;
    void Start()
    {
        obj = gameObject;
        this.ogirinalPosition = obj.transform.position;
        moveSpeed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1*Time.deltaTime*moveSpeed,transform.position.y,0));
        if (Vector3.Distance(ogirinalPosition, obj.transform.position) > moveRange)
        {
            obj.transform.position = this.ogirinalPosition;
        }
    }
}
