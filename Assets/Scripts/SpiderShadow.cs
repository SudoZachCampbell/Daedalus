using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShadow : MonoBehaviour
{
    private GameObject spider;
    // Start is called before the first frame update
    void Start()
    {
        spider = GameObject.Find("BaseMesh_Monster_Spider_1");
        transform.SetPositionAndRotation(new Vector3(spider.transform.position.x + 225f, spider.transform.position.y, spider.transform.position.z), spider.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        var movement = spider.transform.position - transform.position;
        transform.Translate(new Vector3(-movement.x -225f, movement.y, movement.z));
    }
}
