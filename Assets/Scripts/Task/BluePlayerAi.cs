using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BluePlayerAi : MonoBehaviour
{
    [SerializeField]
    float speed = 20f;
    Vector3 boxSize = new Vector3(2, 2, 2);
    [SerializeField]
    GameObject bullet;
    public int health;
    [SerializeField]
    public TMP_Text textMeshPro;
    bool isShoot = false;
    Vector3[] directions = { Vector3.forward, Vector3.right, Vector3.back, Vector3.left };




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayerAi());
    }

    void OnEnable()
    {
        health = 100;
        textMeshPro.text = health.ToString();
        SpawnManager.bluePlayerCount += 1;
    }

    void OnDisable()
    {
        SpawnManager.bluePlayerCount -= 1;
    }

    public void Updatehealth()
    {
        textMeshPro.text = health.ToString();
    }


    IEnumerator PlayerAi()
    {
        while (true)
        {
            foreach (Vector3 dir in directions)
            {
                while (!Physics.Raycast(transform.position, dir, out RaycastHit hitinfo, 10f))
                {
                    if (Physics.BoxCast(transform.position, boxSize, Vector3.forward, out RaycastHit hit, Quaternion.identity, 20f))
                    {
                        if (hit.collider.CompareTag("RedPlayer") || hit.collider.CompareTag("GreenPlayer") && !isShoot)
                        {
                            StartCoroutine(Shoot());

                        }

                    }

                    transform.Translate(dir * speed * Time.deltaTime);
                    // Adding a small delay between each loop iteration to prevent freezing
                    yield return null;

                }
            }
            // Adding a delay to prevent infinite looping without breaks
            yield return null;
        }
    }

        IEnumerator Shoot()
        {
            isShoot = true;
            Instantiate(bullet, transform.position + Vector3.forward * 2, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            isShoot = false;
        }

    }
