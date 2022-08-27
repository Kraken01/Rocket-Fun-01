using System.Collections;
using UnityEngine;

public class Dropper : MonoBehaviour
{
	[SerializeField]
	private GameObject[] spike;

	[SerializeField]
	private float timeToWait;

	private int i;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			StartCoroutine(Drop());
		}
	}

	private IEnumerator Drop()
	{
		spike[i].GetComponent<Rigidbody>().useGravity = true;
		i++;
		yield return new WaitForSeconds(timeToWait);
		if (i < spike.Length)
		{
			StartCoroutine(Drop());
		}
	}
}
