using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinteSpawner : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] GameObject trigger;
   // [SerializeField] float xOffset; 
    [SerializeField] float timeToWait;

    int j = 0;

    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(LaunchMissile());  
    }

    // Update is called once per frame

   /* public void UpdateTile()
    {
        Instantiate(obj, position, Quaternion.identity);
        position = new Vector3(position.x, position.y, position.z );
    }*/

    IEnumerator LaunchMissile()
    {
        float yOffset = Random.Range(0, 15);
        Vector3 randomPosition = transform.position + new Vector3 (0, yOffset, 0);
        Instantiate(obj, randomPosition, Quaternion.identity);
        j++;
        yield return new WaitForSeconds(timeToWait);
        if(j < 15)
        {
            StartCoroutine(LaunchMissile());
        }
    }

}
