using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHolder : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BController.instance != null)
        {
            if(BController.instance.flag == 1)
            {
                Destroy(GetComponent<PHolder>());
            }
        }
        _pipeMovement();
    }

    void _pipeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Died")
        {
            Destroy(gameObject);
        }
    }
}
