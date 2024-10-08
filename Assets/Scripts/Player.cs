using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 20f;
    [SerializeField]
    GameObject Camera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        Camera.transform.position = new Vector3(transform.position.x,Camera.transform.position.y,transform.position.z);
        //if(Physics.Raycast(transform.position,Vector3.forward,out RaycastHit hitinfo,10f) && hitinfo.collider.CompareTag("Enemy"))
        //{
        //    Debug.DrawRay(transform.position, Vector3.forward * 10f, Color.green);
        //    Debug.Log("Enemy Hit");
        //}
    }


    void PlayerMovement() 
    {
    if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

        }
    else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }



}
