using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class testenemyspawser : MonoBehaviour
{
    public GameObject enemy;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1.0)
        {
            timer -= 1;
            Instantiate(enemy);
        }
    }
}
