    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    private Animator anim;
    public GameObject book;
    public bool bookIsClosed;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bookIsClosed = false;

    }

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("Settings");
        }

        if (Input.GetKeyDown("b"))
        {
            if(bookIsClosed == true)
            {
                book.SetActive(true);
                bookIsClosed = false;
            }
            else{
                book.SetActive(false);
                bookIsClosed = true;
            }

        }

        //for player movement
        float dirY = Input.GetAxisRaw("Vertical");
        playerBody.velocity = new Vector2(dirY*2f, playerBody.velocity.y);
        float dirX = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(dirX*2f, playerBody.velocity.x);

        //for animation
        if (dirY > 0f)
        {
            anim.SetBool("GoingUp", true);
        }
        else if (dirY < 0f)
        {
            anim.SetBool("GoingDown", true);
        }
        else if (dirX > 0f)
        {
            anim.SetBool("GoingLeft", true);
        }
        else if (dirX < 0f)
        {
            anim.SetBool("GoingRight", true);
        }

        else{
            anim.SetBool("GoingUp", false);
            anim.SetBool("GoingDown", false);
            anim.SetBool("GoingLeft", false);
            anim.SetBool("GoingRight", false);
        }


    }

}
