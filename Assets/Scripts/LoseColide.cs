using UnityEngine;
using System.Collections;

public class LoseColide : MonoBehaviour {

	private LevelManager levelManager;
	private Ball ball;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger");
        //levelManager.LoadLevel("Lose");
        if (Ball.noOfBalls > 1)
        {
            ball.minusBall();
            ball.ResetBall();
        }
        else {
            levelManager.LoadLevel("Lose");
        }
    }

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        ball = GameObject.FindObjectOfType<Ball>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
