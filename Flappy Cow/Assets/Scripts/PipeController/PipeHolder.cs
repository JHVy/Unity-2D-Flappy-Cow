using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour
{

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CowController.instance != null)
        {
            if(CowController.instance.flag == 1)
            {
                Destroy(GetComponent<PipeHolder>());
            }
        }
        _PipeMovement();
    }

    void _PipeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime; // * detalTime cho game muot hon
        transform.position = temp;
    }

    void OnCollisionEnter2D(Collision2D target)
    {

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
