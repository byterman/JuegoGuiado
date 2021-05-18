using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{
	
	  //Definim les variables runSpeed i jumpSpeed
    public float runSpeed = 1;
    public float jumpSpeed = 3;
 	
 	public AudioSource tickSOurce;
 	
    // Start is called before the first frame update
   Rigidbody2D rb2d;
   SpriteRenderer sprd;
   Animator m_Animator;
 

    // Start is called before the first frame update
    void Start()
    {
    	tickSOurce = GetComponent<AudioSource> ();
        rb2d = GetComponent<Rigidbody2D>();
        sprd = GetComponent<SpriteRenderer>();
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool("Run", false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
 		
        if (Input.GetKey("d") || Input.GetKey("right")){
      		sprd.flipY = false;
        	sprd.flipX = false;
        	m_Animator.SetBool("Run", true);
            pos.x += runSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("a") || Input.GetKey("left")){
        	sprd.flipY = false;
        	sprd.flipX = true;
        	m_Animator.SetBool("Run", true);
 		pos.x -= runSpeed * Time.deltaTime;
 
        }else if((Input.GetKey("w") || Input.GetKey("space")) && CheckGround.isGrounded){
		    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        //else if(Input.GetKey("w") && (collision.CompareTag("Puerta1"))){
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
        //else if (Input.GetKey("w") && (collision.CompareTag("Puerta2")))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        else
        {
            m_Animator.SetBool("Run", false);
        }

	transform.position = pos;
    }
     private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("trampa")){
        	GetComponent<SpriteRenderer>().enabled = false;
        	
        	tickSOurce.Play();
        	
        	gameObject.transform.GetChild(0).gameObject.SetActive(true);
		Destroy(gameObject, 0.5f);
        }
    }
}

   
