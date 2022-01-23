using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMoveForward : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    public float timeRemaining = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        } else
        {
            float step = 10 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }


}
