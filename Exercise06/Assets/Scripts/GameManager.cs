using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int playerScore = 0;
    int enemyScore = 0;
    int coins;
    public TMP_Text scoreText;
    public TMP_Text enemyScoreText;
    public TMP_Text coinText;
    public TMP_Text winDisplay;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin").Length;

        /*
        // This part checks to see if the player just clicked the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from where the player clicked into the 3d world
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {

                // If we get in here, it means that we hit something. 'hit' is
                // an object that Unity filled with all of the info about what the Raycast hit.
                //
                // Check to make sure we actually clicked on the ground. Don't forget to
                // create and add the tag "Ground" to your ground!
                if (hit.collider.CompareTag("Ground"))
                {
                    // Set the destination to where the player clicked.
                    player.nma.SetDestination(hit.point);
                }
            }
        */
        

        coinText.text = "Batteries Left: " + coins; //+ pc.score;

        if (GameObject.FindGameObjectsWithTag("Coin").Length <= 0)
        {
            if (playerScore > enemyScore)
            {
                winDisplay.text = "You found the most batteries! You win!";
            }
            if (enemyScore > playerScore)
            {
                winDisplay.text = "The other robots found the most batteries! Game Over.";
            }

        }

    }

    // This function can be called from other scripts. For example, inside of the
    // PlayerController's OnTriggerEnter function. But remember, the PlayerController
    // would need to have a reference to this GameManager object. This is most
    // easily accomplished by creating a 'public GameManager gm;' in PlayerController
    // and dragging and dropping the GameManager object into the inspector.
    public void IncrementScore()
    {
        playerScore = playerScore + 1;
        scoreText.text = playerScore.ToString();
    }


    // This keeps track of the enemy's score. 
    public void IncrementEnemyScore()
    {
        enemyScore = enemyScore + 1;
        enemyScoreText.text = enemyScore.ToString();
        Debug.Log("Enemy Got A Point!");
    }
}
