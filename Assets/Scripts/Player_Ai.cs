using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Ai : MonoBehaviour
{
    [SerializeField]
    float speed = 20f;
    //[SerializeField]
    //GameObject Camera;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayerAi());
    }

    // Update is called once per frame
    void Update()
    {



    }

    //void LateUpdate()
    //{
    //    Camera.transform.position = new Vector3(transform.position.x, Camera.transform.position.y, transform.position.z);
    //}


    IEnumerator PlayerAi()
    {
        //Detection Forward Enemies 
        while (!Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hitinfo, 10f))
        {
            
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            yield return null;

        }

        //Detection right Enemies 
        while (!Physics.Raycast(transform.position, Vector3.right, out RaycastHit hitinfo, 10f))
        {

            transform.Translate(Vector3.right * speed * Time.deltaTime);
            yield return null;
        }

        //Detection Back Enemies 
        while (!Physics.Raycast(transform.position, Vector3.back, out RaycastHit hitinfo, 10f) )
        {

            transform.Translate(Vector3.back * speed * Time.deltaTime);
            yield return null;
        }

        //Detection left Enemies 
        while (!Physics.Raycast(transform.position, Vector3.left, out RaycastHit hitinfo, 10f) )
        {

            transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }




        StartCoroutine(PlayerAi());

    }

}
