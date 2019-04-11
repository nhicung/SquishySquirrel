﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{

    public AudioClip clip;
    //[SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private int foodID;
    [SerializeField]
    private UIController uiController;

    public int countCollisions;

    // Start is called before the first frame update
    void Start()
    {
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();
        countCollisions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position .y < -5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D (Collider2D other) 
    {
        //Debug.Log(other.tag);
        if (other.tag == "squirrel")
        {
            PlayerController squirrel = other.GetComponent<PlayerController>();

            if (squirrel != null)
            {
                 if (foodID == 1 || foodID == 6)
                 {
                    if (uiController != null)
                    {
                        uiController.DecreaseHealth();
                        AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));

                    }
                  }

                if (foodID == 0 || foodID ==4 || foodID ==5)
                {
                    if (uiController != null)
                    {
                        uiController.UpdateAcorn();
                        //if (PlayerPrefs.GetInt("SFXToggle") == 1)
                        //{
                        AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
                        //}
                    }
                }
                if (foodID == 2 || foodID == 3)
                {
                    uiController.IncreaseHealth();
                    //if (PlayerPrefs.GetInt("SFXToggle") == 1)
                        //{
                    AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
                   
                    //}
                }
                countCollisions = countCollisions + 1;
                Debug.Log("count : " + countCollisions);
                if (countCollisions >= 3)
                {
                    uiController.DecreaseHealth();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
