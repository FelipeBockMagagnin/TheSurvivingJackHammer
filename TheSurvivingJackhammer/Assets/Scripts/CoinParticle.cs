using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParticle : MonoBehaviour
{
    GameObject target;
    float speed;

    void Start()
    {
        target = GameObject.Find("CoinTarget");
        speed = Random.Range(15, 30);
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0,0), Random.Range(-10, 10)), ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
       transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);        
    }
}
