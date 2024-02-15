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


	// Start is called before the first frame update
	void Start()
	{


	}

	// Update is called once per frame
	void Update()
	{
		// función de la linterna
		if (Input.GetMouseButtonDown(0))
		{
			luz.enabled = !luz.enabled;
			//linterna.Play();
		}

		// Display del texto 
		ItemsFoundDisplay.text = SpecialItemsFound + "/6";

	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("aa!");
		if (other.CompareTag("Player") && endGame)
		{
			Debug.Log("Player reached the goal!");
			// You can add logic here to end the game, such as displaying a victory screen or returning to the main menu
			// SceneManager.LoadScene("VictoryScene"); // Load a victory scene, for example
		}
	}

}
