using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = (60 / 130) * 2;
    private float timer;

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(timer > beat)
        {
            GameObject cube = Instantiate(cubes[UnityRandom.Range(0,cubes.Length)], points[UnityRandom.Range(0,points.Length)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * UnityRandom.Range(0, 4));
            timer -= beat;
        }
        timer += Time.deltaTime;
    }
}
