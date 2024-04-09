using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class HapticFeedback : MonoBehaviour
{
    public AudioClip collisionSound;
    public AudioClip powerupSound;
    public AudioClip obstacleSound;
    private XRController xrController;
    private AudioSource audioSource;
    public static int checkpointCounter =0 ;
    private float lastCollisionTime;
    public float collisionCooldown = 1f; // Cooldown period to prevent multiple collisions in the same frame

    public LevelsTransition LevelsTransition;
    public CountDownTimer CountDownTimer;
    public TMP_Text livesCount;



    void Start()
    {
        xrController = GetComponent<XRController>();
        //Debug.Log("controller");

        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the "MazeObject" tag
        if (collision.gameObject.CompareTag("MazeObject"))
        {
            //Debug.Log("collision");
            
            //Debug.Log("buzz");
            audioSource.PlayOneShot(collisionSound);

            // Trigger haptic feedback on the hand controller
            //xrController.SendHapticImpulse(0.7f, 2.0f);

            if (Time.time - lastCollisionTime > collisionCooldown)
            {
                //Debug.Log("Collision detected with a maze");
                ScoreCalculatorMaze.Increment();
                if (ScoreCalculatorMaze.isLevel1)
                {
                    livesCount.text = string.Format("{0}", 2 - ScoreCalculatorMaze.score);
                }
                else if (ScoreCalculatorMaze.isLevel2)
                {
                    livesCount.text = string.Format("{0}", 4 - ScoreCalculatorMaze.score);
                }
                StartCoroutine(ResetTextAfterDelay());
                ///
                if (ScoreCalculatorMaze.isLevel1)
                {
                    if (ScoreCalculatorMaze.score == 2)
                    {
                       // CountDownTimer.OverallTime(1);
                        //Debug.Log("overall time: " + ScoreCalculatorMaze.overallTime);
                        LevelsTransition.checkLevelOne();
                    }
                }
                else if (ScoreCalculatorMaze.isLevel2)
                {
                    if (ScoreCalculatorMaze.score == 4)
                    {
                        //CountDownTimer.OverallTime(2);
                       // Debug.Log("overall time: " + ScoreCalculatorMaze.overallTime);
                        LevelsTransition.CheckLevelTwo();
                    }
                }
            }
        }
        lastCollisionTime = Time.time;

        if (collision.gameObject.CompareTag("MazeObstacle"))
        {
            ScoreCalculatorMaze.Increment();
            livesCount.text = string.Format("{0}", 4-ScoreCalculatorMaze.score);
            StartCoroutine(ResetTextAfterDelay());
            audioSource.PlayOneShot(obstacleSound);
            collision.gameObject.SetActive(false);
            //Debug.Log("Collision with an obstacle!");
            //Destroy(collision.gameObject);

            ///
            if (ScoreCalculatorMaze.isLevel1)
            {
                if (ScoreCalculatorMaze.score == 2)
                {
                    // CountDownTimer.OverallTime(1);
                    //Debug.Log("overall time: " + ScoreCalculatorMaze.overallTime);
                    LevelsTransition.checkLevelOne();
                }
            }
            else if (ScoreCalculatorMaze.isLevel2)
            {
                if (ScoreCalculatorMaze.score == 4)
                {
                    //CountDownTimer.OverallTime(2);
                    // Debug.Log("overall time: " + ScoreCalculatorMaze.overallTime);
                    LevelsTransition.CheckLevelTwo();
                }
            }
        }
        else if (collision.gameObject.CompareTag("MazePowerUp"))
        {
            ScoreCalculatorMaze.Decrement();
            livesCount.text = string.Format("{0}", 4-ScoreCalculatorMaze.score);
            StartCoroutine(ResetTextAfterDelay());
            audioSource.PlayOneShot(powerupSound);
            //Debug.Log("Collision with a power-up!");
            collision.gameObject.SetActive(false);
           // Destroy(collision.gameObject); // Change to inActive

            ///
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            checkpointCounter++;
            //Debug.Log("check " + checkpointCounter);
        }

    }
    IEnumerator ResetTextAfterDelay()
    {
        yield return new WaitForSeconds(3.0f);

        // After waiting for the specified duration, reset the text to nothing
       ScoreCalculatorMaze.reinforcementText = "";
    }
}
