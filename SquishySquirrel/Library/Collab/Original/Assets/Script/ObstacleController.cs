﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // Start is called befothe first frame update
    private float speed = 1.2f;


    [SerializeField]
    private UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.tag);
        if (other.tag == "squirrel")
        {
            PlayerController squirrel = other.GetComponent<PlayerController>();

            if (squirrel != null)
            {
                    if (uiController != null)
                    {
                        uiController.HitRock();
                }

            }
        }
    }
}

