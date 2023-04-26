using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float ogirinalPosition;
    public float minY;
    public float maxY;
    private GameObject obj;
    void Start()
    {
        obj = gameObject;
        ogirinalPosition = 10;
        moveSpeed = 3;
        minY = 0;
        maxY = 2;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag.Equals("ResetWall"))
            obj.transform.position = new Vector3(ogirinalPosition, Random.Range(minY, maxY + 1), 0);
    }
}
