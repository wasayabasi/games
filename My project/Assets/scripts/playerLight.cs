using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLight : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float followSpeed = 5f; // How quickly the light follows the player

    void Update()
    {
        // Move the point light towards the player using Lerp
        transform.position = Vector3.Lerp(transform.position, player.position, followSpeed * Time.deltaTime);
    }

    void Start()
    {
        // Find the player object by tag
        player = GameObject.FindGameObjectWithTag("player").transform;
    }
}
