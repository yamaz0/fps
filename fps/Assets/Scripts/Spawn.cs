using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    public GameObject obj;
    // Update is called once per frame
    void Update()
    {
        if (obj == null)
            obj = Instantiate(enemy, transform);
    }
}
