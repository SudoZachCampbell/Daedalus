using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSight : MonoBehaviour
{
    const int MONSTER_SLEEP = 5;
    public GameObject monster;
    private float reset = MONSTER_SLEEP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reset -= Time.deltaTime;
        if (reset < 0)
        {
            monster.GetComponent<MonsterMovement>().enabled = false;
        }            
    }

    void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            monster.GetComponent<MonsterMovement>().enabled = true;
            reset = MONSTER_SLEEP;
        }
    }
}
