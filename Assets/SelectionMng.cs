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

  [SerializeField] LVLManager lVLManager;

  private Transform _selection;

  public Text SelectionTXT;

  // Start is called before the first frame update
  void Start()
  {
    SelectionTXT.text = "";   
  }

  // Update is called once per frame
  void Update()
  {
    if (_selection != null) {
        _selection = null;
        SelectionTXT.text = "";
    }

    var ray = cam.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit)) {
      var selection = hit.transform;
      // Debug.Log("aksdjfk"); Sí entra
      // Debug.Log(selection);

      if (selection.CompareTag(selectableTag)) 
      {

        // task 1
        if (selection.name.Equals("TableSchool (6)")) {
          // Debug.Log("Mesa 6!");

          SelectionTXT.text = "[F] para arreglar";

          if (Input.GetKey(KeyCode.F)) {
            selection.transform.position = new Vector3(23.667f, 3.826f, 5.133f);
            selection.transform.rotation = Quaternion.Euler(-180.0f, -87.3f, -180.0f);

            lVLManager.c1 += 1;
            lVLManager.task1_counter.text = lVLManager.c1 + "/2";

            SelectionTXT.text = "";
            selection.tag = "Untagged";
          }
        }

        if (selection.name.Equals("TableSchool (8)")) {
          // Debug.Log("Mesa 8!");

          SelectionTXT.text = "[F] para arreglar";
                
          if (Input.GetKey(KeyCode.F)) {
            selection.transform.position = new Vector3(25.77f, 3.813902f, 3.23f);
            selection.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);

            lVLManager.c1 += 1;
            lVLManager.task1_counter.text = lVLManager.c1 + "/2";

            SelectionTXT.text = "";
            selection.tag = "Untagged";
          }
        }

        _selection = selection;
      }
        
    }

    // Debug.Log(hasSelection);

  }
}
