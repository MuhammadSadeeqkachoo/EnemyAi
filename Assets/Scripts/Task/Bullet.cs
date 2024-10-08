using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 50f;
    AudioSource shootingsound;

    private void Awake()
    {
        shootingsound = GetComponent<AudioSource>();

    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BulletDisapperTime());
        
    }

    private void OnEnable()
    {
        shootingsound.Play();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BluePlayer")) 
        {
            GameObject blueplayer = collision.collider.gameObject;
            BluePlayerAi bluePlayerAi = blueplayer.GetComponent<BluePlayerAi>();
            bluePlayerAi.health -= 10;
            bluePlayerAi.Updatehealth();
            if(bluePlayerAi.health < 10)
            {
                Destroy(collision.collider.gameObject);
            }

        }
        else if (collision.collider.CompareTag("GreenPlayer"))
        {
            GameObject greenplayer = collision.collider.gameObject;
            GreenPlayerAi greenPlayerAi = greenplayer.GetComponent<GreenPlayerAi>();
            greenPlayerAi.health -= 10;
            greenPlayerAi.Updatehealth();
            if (greenPlayerAi.health < 10)
            {
                Destroy(collision.collider.gameObject);
            }

        }
        else if (collision.collider.CompareTag("RedPlayer"))
        {
            GameObject redplayer = collision.collider.gameObject;
            RedPlayerAi redPlayerAi = redplayer.GetComponent<RedPlayerAi>();
            redPlayerAi.health -= 10;
            redPlayerAi.Updatehealth();
            if (redPlayerAi.health < 10)
            {
                Destroy(collision.collider.gameObject);
            }

        }

        Destroy(gameObject);//destroy Bullet



    }


    IEnumerator BulletDisapperTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
