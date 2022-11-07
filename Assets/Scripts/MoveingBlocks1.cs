using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveingBlocks1 : MonoBehaviour
{
    public bool isDone;
public bool blockIsMovable;
    public bool playerIsInRange;
    public bool blockIsAtCorrectSpot=false;

    public GameObject theBlock;
    public GameObject spotForTheBlock;
    public Rigidbody2D blockBody;

    public float mass;
    public float dirY;
    public float dirX;
    
    // Start is called before the first frame update
    void Start()
    {
        dirY = Input.GetAxisRaw("Vertical");
        dirX = Input.GetAxisRaw("Horizontal");
        blockBody = gameObject.GetComponent<Rigidbody2D>();
       // blockBody.mass=100000f;
    }

    // Update is called once per frame
    void Update()
    {
        //This section is used to move the blocks
        if(playerIsInRange&&blockIsAtCorrectSpot==false)
        {
        blockBody.velocity = new Vector2(dirY*2f, blockBody.velocity.y);
        blockBody.velocity = new Vector2(dirX*2f, blockBody.velocity.x);
        }

        else{
        blockBody.velocity = new Vector2(dirY*0f, blockBody.velocity.y);
        blockBody.velocity = new Vector2(dirX*0f, blockBody.velocity.x);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           playerIsInRange=true;
           Debug.Log("CONNECTED");
        }
        else if(other.CompareTag("Spot1"))
        {
           blockIsAtCorrectSpot = true;
           //Debug.Log("YESYESYES");
           blockBody.mass=100000f;
            if(isDone==false){
                isDone=true;
                GameManager.instance.currentSolved++;
                GameManager.instance.ChangeScene();
            }
        }
    }
        public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsInRange=false;
        }
    }
}
