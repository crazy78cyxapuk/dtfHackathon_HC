using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllEnemy : MonoBehaviour
{
    private Vector2 dir;
    private float speed = 2f;
    private GameObject player;

    private void Start()
    {
        dir = Vector2.left;
        player = GameObject.Find("player");
    }

    private void Update()
    {
        if (transform.position.x > 2.3)
        {
            dir = Vector2.left;
        }
        else
        {
            if (transform.position.x < -2.3)
            {
                dir = Vector2.right;
            }
        }

        transform.Translate(dir * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, player.transform.position) > 50)
        {
            Destroy(gameObject);
        }
    }
}
