using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpoint : MonoBehaviour
{
    public GameObject enemyPrifab;
    public float spownRate = 2f;

    private float timer = 0f;
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spownRate)
        {
            timer = 0f;
            Instantiate(enemyPrifab,transform.position,transform.rotation);
        }
    }
}
