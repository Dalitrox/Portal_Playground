﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejector : MonoBehaviour
{
    public GameObject Cube;
    public GameObject SpawnPoint;
    AudioSource aSource;
    public List<GameObject> ObjectToOvserveList = new List<GameObject>();
    public List<bool> ObjectStateCheckboxList = new List<bool>();
    bool check = false;
    public int maxSpawn = 1;

    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }

    public void Spawn()
    {
        if (maxSpawn > 0)
        {
            Instantiate(Cube, SpawnPoint.transform.position, Quaternion.Euler(0, 0, 0));
            aSource.Play();
            maxSpawn -= 1;
        }
        else
        {
            Debug.Log("Ejector został wykorzystany!");
        }
    }

    public void Check()
    {
        bool currentCheck = true;

        if (ObjectToOvserveList.Count < 1 || ObjectStateCheckboxList.Count < 1)
        {
            return;
        }

        for (int i = 0; i < ObjectToOvserveList.Count; i++)
        {
            if (ObjectToOvserveList[i].GetComponent<Animator>().GetBool("isPressed") != ObjectStateCheckboxList[i])
            {
                currentCheck = false;
            }
        }

        if (currentCheck != check)
        {
            if (currentCheck)
            {
                Spawn();
            }
            check = currentCheck;
        }
    }
}
