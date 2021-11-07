using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformScript : MonoBehaviour
{
    public float move_speed = 2f;
    public float bound_y = 7.5f;
    private Animator anim;
    public bool isPlatform,isStar, isCrackablePlatform, isSpikePlatform, isSpeed_Platform_Left, isSpeed_Platform_Right;
    public float movement_platform_speed_left = -1f , movement_platform_speed_right =1f;
    // Start is called before the first frame update
    private void Awake()
    {
       
        if (isCrackablePlatform)
        {
            anim = GetComponent<Animator>();
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }
    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_speed * Time.deltaTime;
        transform.position = temp;
        
        if(temp.y >= bound_y)
        {
            gameObject.SetActive(false);
        }

    }
    void breakableDeactive()
    {
        Invoke("DeactiveGame", 0.5f);
    }
    void DeactiveGame()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }
     void OnTriggerEnter2D(Collider2D target)
    {
       if(target.tag == "Player")
        {
            if (isSpikePlatform)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
            
           
        }
    }//onTriggerEnter
     void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            if (isCrackablePlatform)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }
            if (isPlatform)
            {
                SoundManager.instance.LandSound();
            }
        }        
    }//oncollision Enter
     void OnCollisionStay2D(Collision2D target)
    {
        
        if(target.gameObject.tag == "Player")
        {
            if (isSpeed_Platform_Left)
            {
                target.gameObject.GetComponent<PlayerMovement>().platformMove(movement_platform_speed_left);
             }
            if (isSpeed_Platform_Right)
            {
                target.gameObject.GetComponent<PlayerMovement>().platformMove(movement_platform_speed_right);
            }
        }
    }







}//class



