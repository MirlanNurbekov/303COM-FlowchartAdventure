using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Each block got specific place named as a spot. 
The block must be movable only when user is pushing it and only when it is not located on it's spot. 
The moment block is located at the correct spot it should become unmovable.*/

public class MovingBlocks : MonoBehaviour
{
    //to end the lvl
    public bool isDone;
//
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
        else if(other.CompareTag("Spot2"))
        {
           blockIsAtCorrectSpot = true;
           Debug.Log("YESYESYES");
           blockBody.mass=100000f;
           //to end the lvl
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
