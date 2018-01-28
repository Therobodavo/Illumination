﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour {

    public PlayerMoveScript script;

    public Sprite lit;
    public Sprite unlit;

    public bool isLit;

    public GameObject door;

    public AudioSource lightSound;

	// Use this for initialization
	void Start () {
        door = GameObject.FindGameObjectWithTag("Door");

        isLit = false;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            if (script.isLaser && !isLit)
            {
                Light();
            }
        }
    }

    void Light()
    {
        isLit = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = lit;
        TriggerDoor td = door.GetComponent<TriggerDoor>();
        td.CountLantern();

        lightSound.Play();
    }

    private void Reset()
    {
        isLit = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = unlit;
        TriggerDoor td = door.GetComponent<TriggerDoor>();
        td.UncountLantern();
    }
}
