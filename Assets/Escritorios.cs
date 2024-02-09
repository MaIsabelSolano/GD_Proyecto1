using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escritorios : MonoBehaviour
{

  public int DeskNum;
  public bool interact;
  GameObject parentDesk;
  LVLManager lVLManager;
  // Start is called before the first frame update
  void Start()
  {
    parentDesk.GetComponentInParent<GameObject>();
  }

  // Update is called once per frame
  void Update()
  {
      if (interact != Input.GetKeyDown(KeyCode.F)) {
        // toggle
        interact = !interact;
        Debug.Log("Toggle: ");
        Debug.Log(interact);
      }
  }

  private void OnTriggerEnter(Collider other) 
  {
    if (other.CompareTag("Player")){
      Debug.Log("hey!");
      if (interact){
        if (DeskNum == 1) {
          Debug.Log("entra");
          transform.parent.position = new Vector3(25.77f, 3.813902f, 3.23f);
          transform.parent.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);

        } else if (DeskNum == 2) {
          Debug.Log("entra2");
          transform.parent.position = new Vector3(23.667f, 3.826f, 5.133f);
          transform.parent.rotation = Quaternion.Euler(-180.0f, -87.3f, -180.0f);
          
        }
      }
    }
  }
}
