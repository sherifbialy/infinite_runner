using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    Rigidbody r;
    public float JumpForce;
    public float speed;
    private int Score=0;
    public float LaneDistance;
    public float groundDistance=1.0f;
    public TMP_Text score;
    public TMP_Text health;
    public TMP_Text ability;
    public TMP_Text finalscore;

    // public float gravityScale = 2;
    private int Health=5;
    private int Ability = 10;
    private bool gameover = false;
    private bool ispaused = false;
    public GameObject gameoverpanel;
    public GameObject HUD;
    public GameObject pausepanel;
    //private bool isGrounded = true;
    private bool shouldJump = false;
    CharacterController controller;
    public AudioSource GoodSoundEffect;
    public AudioSource BadSoundEffect;
    public AudioSource RunSoundEffect;
    public AudioSource PauseSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        r = this.GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        gameoverpanel.SetActive(false);
        pausepanel.SetActive(false);
        RunSoundEffect.Play();
        Time.timeScale = 1;
        //RunSoundEffect.PlayDelayed(120);
       // RunSoundEffect.PlayDelayed(240);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        movement = movement.normalized;
        movement *= speed;
        r.velocity = new Vector3(movement.x, r.velocity.y, movement.z);
       
        if (Input.GetKeyUp(KeyCode.Space) && Ability > 0 && isGrounded())
        {

                
               Ability--;
           // r.velocity = new Vector3(movement.x, JumpForce, movement.z);
            shouldJump = true;
            ability.text = "Ability=" + Ability;


        }
        if (Input.GetKeyDown(KeyCode.Q) && Ability > 5)
        {
            Ability = Ability - 5;
            GoodSoundEffect.Play();
            ability.text = "Ability=" + Ability;
            SpecialAbility();

        }
        if (Input.GetKeyDown(KeyCode.Escape)&& ispaused)
        {
            
            Resume();
           

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !ispaused)
        {
            Pause();
           

        }
       
        GameOver(Health);
        if (GameOver(Health)==true)
        {
            playermanager.gameover = true;
            Time.timeScale = 0;

            PauseSoundEffect.Play();
            PauseSoundEffect.mute = false;
            RunSoundEffect.mute = true;
            gameoverpanel.SetActive(true);
            finalscore.text = "Your Score is " + Score;
           HUD.SetActive(false);

        }
    
    }
        void OnTriggerEnter(Collider orb)
        {
            if (orb.CompareTag("AbilityOrb")&&Ability<10)
            {
                Ability++;
            ability.text = "Ability=" + Ability;
            Destroy(orb.gameObject);
            GoodSoundEffect.Play();
        }
        else if (orb.CompareTag("AbilityOrb") && Ability >= 10)
            {
                Ability = 10;
                Destroy(orb.gameObject);
            GoodSoundEffect.Play();
        }
        else if (orb.CompareTag("HealthOrb") && Health < 5)
            {
                Health++;
            GoodSoundEffect.Play();
            health.text = "Health=" + Health;

            Destroy(orb.gameObject);
            }
            else if (orb.CompareTag("HealthOrb") && Health >= 5)
            {
                Health = 5;
                Destroy(orb.gameObject);
            GoodSoundEffect.Play();
        }

        // CoinSoundEffect.Play();

        //Destroy(orb.gameObject);
    }
        bool GameOver(int val)
        {
            if (val <= 0)
            {
            gameover = true;
           
            }
        else
        {
            gameover = false;
        }
        return gameover;
    }
    void OnCollisionEnter(Collision collision) //OnCollisionExit
    {
        if (collision.collider.CompareTag("Obstacle1"))
        {
            Health--;
            health.text = "Health=" + Health;
            Destroy(collision.gameObject);
            BadSoundEffect.Play();
        }
        if (collision.collider.CompareTag("Obstacle2"))
        {
            Health=Health-2;
            health.text = "Health=" + Health;
            Destroy(collision.gameObject);
            BadSoundEffect.Play();
        }
        if (collision.collider.CompareTag("Obstacle3"))
        {
            Health=Health-3;
            health.text = "Health=" + Health;
            Destroy(collision.gameObject);
            BadSoundEffect.Play();
        }
        if (collision.collider.CompareTag("Obstacle1d"))
        {
            Score++;
            score.text = "Score=" + Score;
            Destroy(collision.gameObject);
            GoodSoundEffect.Play();
            Debug.Log(Score + "");

        }
        if (collision.collider.CompareTag("Obstacle2d"))
        {
            Score += 2;
            score.text = "Score=" + Score;
            Destroy(collision.gameObject);
            GoodSoundEffect.Play();
            Debug.Log(Score + "");

        }
        if (collision.collider.CompareTag("Obstacle3d"))
        {
            Score += 3;
            score.text = "Score=" + Score;
            Destroy(collision.gameObject);
            GoodSoundEffect.Play();
            Debug.Log(Score + "");

        }
     

    }
  //  void OnCollisionExit(Collision col)
   // {
     //   if (col.collider.CompareTag("Ground"))
       // {
           // isGrounded = false;
      //  }
   // }
    void SpecialAbility()
    {
        DestroyWithTag("Obstacle1");
        DestroyWithTag("Obstacle2");
        DestroyWithTag("Obstacle3");
        DestroyWithTag("Obstacle1d");
        DestroyWithTag("Obstacle2d");
        DestroyWithTag("Obstacle3d");

    }
    void DestroyWithTag(string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
    }
    public void Pause()
    {
        //PlayerScript.pausepanel.SetActive(true);
        ispaused = true;
        Time.timeScale = 0;
        pausepanel.SetActive(true);
        HUD.SetActive(false);
        PauseSoundEffect.Play();
        PauseSoundEffect.mute = false;
        RunSoundEffect.mute = true;
    }
    public void Resume()
    {
        // PlayerScript.pausepanel.SetActive(false);
        ispaused = false;
        Time.timeScale = 1;
        pausepanel.SetActive(false);
        HUD.SetActive(true);
       PauseSoundEffect.mute = true;

        RunSoundEffect.mute =false;
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }
    // void OnCollisionStay(Collision collision)
    // {

       // if (collision.collider.CompareTag("Ground"))
       // {
          //  isGrounded = true;
        //}
    //}

     void FixedUpdate()
    {
        // Check for jump
        if (isGrounded() && shouldJump)
       {
            shouldJump = false;
           // r.velocity = new Vector3(movement.x, JumpForce, movement.z);
            r.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
       }
    }
}



