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
        // Asigna el componente GameObject del padre a la variable parentDesk
        parentDesk = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica si la tecla "F" fue presionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Toggle
            interact = !interact;
            Debug.Log("Toggle: " + interact);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hey!");
            if (interact)
            {
                if (DeskNum == 1)
                {
                    Debug.Log("entra");
                    parentDesk.transform.position = new Vector3(25.77f, 3.813902f, 3.23f);
                    parentDesk.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                }
                else if (DeskNum == 2)
                {
                    Debug.Log("entra2");
                    parentDesk.transform.position = new Vector3(23.667f, 3.826f, 5.133f);
                    parentDesk.transform.rotation = Quaternion.Euler(-180.0f, -87.3f, -180.0f);
                }
            }
        }
    }
}
