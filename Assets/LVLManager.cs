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
    [SerializeField] Light luz;
    // AudioSource linterna;

    // UI
    private bool pause;
    [SerializeField] int SpecialItemsFound = 0;

    public Text ItemsFoundDisplay;
    //public Text SelectionTXT;
    
    // tareas
    private bool tareasOn;
    [SerializeField] GameObject listUI;

    [SerializeField] SelectionMng selectionMng;

    // Tasks ------------------------------------------------------
    // task 1 -----------------------------------------------------
    public bool task1 = false;
    public int c1;
    [SerializeField] public Text task1_counter;
    public bool T1_E6 = false;
    public bool T1_E8 = false;

    // task 2 -----------------------------------------------------
    public bool task2 = false;
    public bool task3 = false;
    public bool task4 = false;
    public bool task5 = false;
    public bool task6 = false;
    

    // Start is called before the first frame update
    void Start()
    {
        // ItemsFoundDisplay = GetComponent<TextMesh>();
        // pause = false;
        listUI.SetActive(false);
        //SelectionTXT.text = "";
        c1 = 0;
        task1_counter.text = "0/2";
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

        // tareas 
        // if (Input.GetKey(KeyCode.T)) {
        //     tareasOn = !tareasOn; // toggle 

        //     if (tareasOn) {
        //         listUI.SetActive(false);
        //     } else {
        //         listUI.SetActive(true);
        //     }
        // }


    }


}
