using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    InfinteSpawner s;

    private void Start()
    {
        s = GameObject.Find("GameObject").GetComponent<InfinteSpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //s.UpdateTile();
        Destroy(transform.parent.gameObject,2f);
    }
}
