using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl1Dialog : MonoBehaviour
{
    public GameObject dialogBox;
    public bool playerInRange;
    public GameObject ClueIsNear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            dialogBox.SetActive(true);
            }
        else if(Input.GetKeyDown(KeyCode.Space)&&playerInRange==false)
         {
                dialogBox.SetActive(false);
            }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           playerInRange=true;
           Debug.Log("SHE CAN SEE ME");
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
