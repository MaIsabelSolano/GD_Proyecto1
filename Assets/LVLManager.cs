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
    // public Text tag_objeto;
    [SerializeField]
    Light luz;
    // AudioSource linterna;

    // UI
    private bool pause;
    [SerializeField]
    int SpecialItemsFound = 0;

    public Text ItemsFoundDisplay;
    
    // tareas
    private bool tareasOn;
    [SerializeField]
    GameObject listUI;

    // Start is called before the first frame update
    void Start()
    {
        // ItemsFoundDisplay = GetComponent<TextMesh>();
        pause = false;
        listUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // función de la linterna
        if (Input.GetMouseButtonDown(0))
        {
            luz.enabled = luz.enabled ? false : true;
            //linterna.Play();
        }

        // Display del texto 
        ItemsFoundDisplay.text = SpecialItemsFound + "/6";

        // tareas 
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("ttt  ");
            tareasOn = !tareasOn; // toggle 

            if (tareasOn) {
                listUI.SetActive(false);
            } else {
                listUI.SetActive(true);
            }
        }

    }
}
