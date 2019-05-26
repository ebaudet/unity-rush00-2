using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
	public GameObject[]	enemyTags;
	public GameObject	winScreen;
	public Text			lastText;
	public GameObject	nextLevelText;
	public GameObject	retryText;
	public GameObject	loseScreen;
	public GameObject	pauseScreen;
	public AudioClip	winClip;
	public AudioClip	loseClip;

	[SerializeField] private List<GameObject>	_enemies;
    private bool _pause = false;

    // Use this for initialization
    void Start ()
	{
		Time.timeScale = 1;
		winScreen.gameObject.SetActive(false);
		loseScreen.gameObject.SetActive(false);
		pauseScreen.gameObject.SetActive(false);
		
		enemyTags = GameObject.FindGameObjectsWithTag("enemi");
		// Si on retire le tag ennemi sur les bodys, juste besoin de:
		// _enemies.AddRange(enemyTags);
		foreach (GameObject enemy in enemyTags)
		{
			if (enemy.name.Contains("enemi")== true)
				_enemies.Add(enemy);
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown("escape"))
			TogglePause();

		if (Input.GetKeyDown("backspace"))
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				
		for (int i = 0; i < _enemies.Count; i++)
		{
			if (_enemies[i] == null)
				_enemies.Remove(_enemies[i]);
		}
		
		if (player.instance.isAlive == false)
		{
			GetComponent<AudioSource>().clip = loseClip;
			GetComponent<AudioSource>().Play();	
			loseScreen.SetActive(true);
			Time.timeScale = 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "Player" && _enemies.Count == 0)
		{
			if (Application.CanStreamedLevelBeLoaded(SceneManager.GetActiveScene().buildIndex + 1) == false)
			{
				lastText.text = "YOU WIN";
				nextLevelText.SetActive(false);
				retryText.SetActive(false);
			}
			GetComponent<AudioSource>().clip = winClip;
			GetComponent<AudioSource>().Play();
			winScreen.SetActive(true);
			Time.timeScale = 0;
		}

	}

	public void NextLevel()
	{
		int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
		if (Application.CanStreamedLevelBeLoaded(nextIndex))
			SceneManager.LoadScene(nextIndex);
		else
			Debug.Log("This is already the last level !");
	}

	public void RetryLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ExitLevel()
	{
		SceneManager.LoadScene(0);
	} 

	public void TogglePause()
	{
		if (_pause == false)
		{
			_pause = true;
			Time.timeScale = 0;
			pauseScreen.gameObject.SetActive(_pause);
		}
		else
		{
			_pause = false;
			Time.timeScale = 1;
			pauseScreen.gameObject.SetActive(_pause);
		}
	}
}
