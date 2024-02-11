using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionMng : MonoBehaviour
{
  [SerializeField] private string selectableTag = "Selectable";
  [SerializeField] private Camera cam;
  // [SerializeField] LVLManager lVLManager;
  [SerializeField] GameObject listUI;

  public Text SelectionTXT;

  // tasks -------------------------------------------------------------------------
  // task 1 ---------------------
  [SerializeField] Text task1_counter;
  private int c1;

  // task 2 ---------------------
  [SerializeField] Text task2_counter;
  private int c2;

  // task 3 ---------------------
  [SerializeField] Text task3_counter;
  private int c3;
  [SerializeField] GameObject shellFixed;

  // Start is called before the first frame update
  void Start()
  {
    SelectionTXT.text = "";   
    task1_counter.text = "0/2";
    task2_counter.text = "0/2";
    task3_counter.text = "0/4";
  }

  // Update is called once per frame
  void Update()
  {
    // listado de tareas
    if (Input.GetKeyDown(KeyCode.T)) {
      listUI.SetActive(!listUI.active);
    }

    var ray = cam.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit)) {
      var selection = hit.transform;

      if (selection.CompareTag(selectableTag)) 
      {
        // task 1 ------------------------------------------------------------------------------
        if (selection.name.Equals("TableSchool (6)")) {
          SelectionTXT.text = "[F] para arreglar";

          if (Input.GetKey(KeyCode.F)) {
            selection.transform.SetPositionAndRotation(new Vector3(23.667f, 3.826f, 5.133f), Quaternion.Euler(-180.0f, -87.3f, -180.0f));

            CompleteTask(1);
            selection.tag = "Untagged";
          }
        } else if (selection.name.Equals("TableSchool (8)")) {
          SelectionTXT.text = "[F] para arreglar";

          if (Input.GetKey(KeyCode.F)) {
            selection.transform.SetPositionAndRotation(new Vector3(25.77f, 3.813902f, 3.23f), Quaternion.Euler(0.0f, -90.0f, 0.0f));

            CompleteTask(1);
            selection.tag = "Untagged";
          }
        }

        // task 2
        else if (selection.name.Equals("Fridge_DoorD")) {
          SelectionTXT.text = "[F] para cerrar";

          if (Input.GetKey(KeyCode.F)) {
            selection.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);

            CompleteTask(2);
            selection.tag = "Untagged";
            Debug.Log("F");
          }
        } else if (selection.name.Equals("Fridge_DoorH")) {
          SelectionTXT.text = "[F] para cerrar";

          if (Input.GetKey(KeyCode.F)) {
            selection.transform.rotation = Quaternion.Euler(0.0f, -180.0f, 0.0f);

            CompleteTask(2);
            selection.tag = "Untagged";
            Debug.Log("F");
          }
        }

        // task 3
        else if (
          selection.name.Equals("CupboardLight_Broken") || 
          selection.name.Equals("CupboardLight_Broken (1)") ||
          selection.name.Equals("CupboardLight_Broken (2)") ||
          selection.name.Equals("CupboardLight_Broken (3)")
        ) {
          SelectionTXT.text = "[F] para arreglar";

          if (Input.GetKey(KeyCode.F)) {
            var pos = selection.position;
            var rot= selection.rotation;

            Destroy(selection.gameObject);
            Instantiate(shellFixed, pos, rot);

            CompleteTask(3);
            // selection.tag = "Untagged";
            Debug.Log("F");
          }
        }
      }

      else {
        SelectionTXT.text = "";
        selection = null;
      }
    }
  }

  void CompleteTask(int taskNum){
    if (taskNum == 1) {
      c1 += 1;
      task1_counter.text = c1.ToString() + "/2";
      if (c1 <= 2) {}
    } else if (taskNum == 2) {
      c2 += 1;
      task2_counter.text = c2.ToString() + "/2";
    } else if (taskNum == 3) {
      c3 += 1;
      task3_counter.text = c3.ToString() + "/4";
    }
  }
}
