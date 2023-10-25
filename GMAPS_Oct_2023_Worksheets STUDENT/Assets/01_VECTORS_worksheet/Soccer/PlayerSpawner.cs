using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.UIElements;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject captain;
    [SerializeField]
    GameObject player;
    [SerializeField]
    float numberOfPlayers;

    float angle, deg;
    void Start()
    {
        angle = 360f;
        deg = angle / numberOfPlayers;

        for (int i = 0; i < numberOfPlayers; i++)
        {
            float ang = deg * i;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
