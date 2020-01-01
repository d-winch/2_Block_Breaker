using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    private bool stickyBall = false;
    public static int noOfBalls = 3;
    public Text ballText;

    // Use this for initialization
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        ballText = GameObject.FindObjectOfType<Text>();
        ballText.text = "x " + noOfBalls;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            //Lock the ball, relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector + new Vector3(0f,0.02f);

            //Mouse click to launch
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Left mouse button clicked");
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                hasStarted = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit object: " + col.transform.name);
        if (col.transform.name == "paddleBlue")
        {
            if (!stickyBall && hasStarted == true)
            {
                Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
                GetComponent<Rigidbody2D>().velocity += tweak;
                if (hasStarted)
                {
                    GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                hasStarted = false;
            }
        }
        else
        {
            Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }

    public void addBall()
    {
        noOfBalls++;
        updateBallText();
    }

    public void minusBall()
    {
        noOfBalls--;
        updateBallText();
    }

    public void ResetBall()
    {
        hasStarted = false;
    }

    public void StickyBall()
    {
        stickyBall = true;
        Debug.Log("Sticky Ball: " + stickyBall);
    }

    public void updateBallText()
    {
        ballText.text = "x " + noOfBalls;
    }
}
