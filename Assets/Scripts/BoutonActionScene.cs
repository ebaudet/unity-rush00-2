using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoutonActionScene : MonoBehaviour {
	public enum actionButton {
		quit_game,
		goto_level,
		goto_scene_name,
		goto_scene_id
	}
	public actionButton action;
	public string scene_name = null;
	public int scene_id = 0;

	protected Button b;

	// Use this for initialization
	void Start () {
		b = GetComponent<Button>();
		b.onClick.AddListener(onClickEvent);
	}

	void onClickEvent()
	{
		if (action == actionButton.quit_game){
			Debug.Log("quit game");
			Application.Quit();
		}
		else if (action == actionButton.goto_scene_name)
		{
			// Debug.Log("changement scene : " + scene_name);
			SceneManager.LoadScene(scene_name);
		}
		else if (action == actionButton.goto_scene_id)
		{
			// Debug.Log("changement scene : " + scene_id);
			SceneManager.LoadScene(scene_id);
		}
	}
}
