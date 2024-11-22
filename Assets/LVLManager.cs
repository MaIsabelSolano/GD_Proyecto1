using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVLManager : MonoBehaviour
{
	//propiedades
	[SerializeField] Light luz;

	// UI
	private bool pause;
	[SerializeField] int SpecialItemsFound = 0;
	public Text ItemsFoundDisplay;

	// Fin del juego 
	// [SerializeField] GameObject meta;
	public bool endGame = false;

	private float previousTimeScale;

	[SerializeField] GameObject pauseMenu;
	[SerializeField] GameObject endGameScreen;


	// Start is called before the first frame update
	void Start()
	{
		pauseMenu.SetActive(false);
		pause = false;
		AudioListener.pause = false;
		Time.timeScale = 1;
		previousTimeScale = Time.timeScale;
		endGameScreen.SetActive(false);

	}

	// Update is called once per frame
	void Update()
	{
		// función de la linterna
		if (Input.GetMouseButtonDown(0) && !pause && !endGame)
		{
			luz.enabled = !luz.enabled;

			//linterna.Play();
		}

		// Display del texto 
		ItemsFoundDisplay.text = SpecialItemsFound + "/6";

		if (Input.GetKeyDown(KeyCode.Escape) && !endGame)
		{
			if (Time.timeScale == 0)
			{
				Time.timeScale = previousTimeScale;
				pauseMenu.SetActive(false);
				pause = false;
				AudioListener.pause = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
			else
			{
				previousTimeScale = Time.timeScale;
				Time.timeScale = 0;
				pauseMenu.SetActive(true);
				pause = true;
				AudioListener.pause = true;
				Cursor.lockState = CursorLockMode.None;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("aa!");
		if (other.CompareTag("Player") && endGame)
		{
			Debug.Log("Player reached the goal!");
			previousTimeScale = Time.timeScale;
			Time.timeScale = 0;
			endGameScreen.SetActive(true);
			AudioListener.pause = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void RepeatLevel()
	{
		SceneManager.LoadScene(1);
	}

	public void ReturnToMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void ResumeGame()
	{
		Debug.Log("ResumeGame() fue llamado.");
		Time.timeScale = 1;
		Debug.Log("Time.timeScale después de reanudar: " + Time.timeScale);
		pauseMenu.SetActive(false);
		pause = false;
		AudioListener.pause = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void IncrementSpecialItemsFound()
	{
		Debug.Log("IncrementSpecialItemsFound() fue llamado.");
		SpecialItemsFound++;
		Debug.Log("SpecialItemsFound: " + SpecialItemsFound);
		ItemsFoundDisplay.text = SpecialItemsFound + "/6";

		if (SpecialItemsFound == 6)
		{
			ShowVictoryScene();
		}
	}

	private void ShowVictoryScene()
	{
		SceneManager.LoadScene("VictoryScene");
		Debug.Log("¡Has colocado los 6 objetos! ¡Victoria!");
	}

}