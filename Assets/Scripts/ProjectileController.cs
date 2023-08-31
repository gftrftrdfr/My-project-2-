using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 4f;
    public GameObject[] Slimes;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        Slimes = GameObject.FindGameObjectsWithTag("Enemy");
    }

        // Update is called once per frame
    void Update()
    {
        foreach (GameObject Slime in Slimes)
        {
            distance = Vector2.Distance(transform.position, Slime.transform.position);
            Vector2 dir = Slime.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, Slime.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
