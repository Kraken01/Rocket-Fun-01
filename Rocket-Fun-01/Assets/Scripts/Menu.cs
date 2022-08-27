using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	[SerializeField]
	private GameObject controls;

	public void StarGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Controls()
	{
		GetComponent<Canvas>().enabled = false;
		controls.GetComponent<Canvas>().enabled = true;
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
