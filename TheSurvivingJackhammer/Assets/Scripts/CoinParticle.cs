using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParticle : MonoBehaviour
{
    GameObject target;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("CoinTarget");
        speed = Random.Range(15, 30);
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0,0), Random.Range(-10, 10)), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);        
    }
}
