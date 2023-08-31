using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public GameObject Player;
    public float speed;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 dir = Player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
    }

}
