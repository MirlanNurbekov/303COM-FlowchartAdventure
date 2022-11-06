using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePopup : MonoBehaviour
{
    
    public GameObject popupBox;
    public bool playerInRange;
    public GameObject ClueIsNear;

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            ClueIsNear.SetActive(true);
        }
        else{
            ClueIsNear.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&playerInRange)
        {
            popupBox.SetActive(true);
            }
        else if(Input.GetKeyDown(KeyCode.Space)||playerInRange==false)
         {
                popupBox.SetActive(false);
            }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           playerInRange=true;
        }
    }
        private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange=false;
        }
    }
}
