using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListScript : MonoBehaviour
{
    public bool CheckingLinst = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckingLinst) {
            storeList();
        } else {
            openList();
        }
        
    }

    private void storeList() {}
    private void openList() {}
}
