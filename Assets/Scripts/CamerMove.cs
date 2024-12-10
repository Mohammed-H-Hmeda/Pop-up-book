using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CamerMove : MonoBehaviour
{
    public Transform Lookatme;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed=5;
       
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward*Time.deltaTime*speed);
        }
        else if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back*Time.deltaTime*speed);
        }
        else if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left*Time.deltaTime*speed);
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right*Time.deltaTime*speed);
        }
        transform.LookAt(Lookatme);
    }
}
