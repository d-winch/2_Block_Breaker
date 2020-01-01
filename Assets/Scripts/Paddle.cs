using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = true;
	private Ball ball;
    private float leftBound = 0.75f;
    private float rightBound = 15.25f;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        AutoToggle();
        if (!autoPlay)
        {
            MouseMove();
        }
        else {
            AutoPlay();
        }
    }

    void MouseMove()
    {
        Vector3 paddlePosition = new Vector3(8, this.transform.position.y, 0);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePosition.x = Mathf.Clamp(mousePosInBlocks, leftBound, rightBound);
        this.transform.position = paddlePosition;
    }

    void AutoPlay()
    {
        Vector3 paddlePosition = new Vector3(8, this.transform.position.y, 0);
        Vector3 ballPosition = ball.transform.position;
        paddlePosition.x = Mathf.Clamp(ballPosition.x, leftBound, rightBound);
        this.transform.position = paddlePosition;
    }

    public void ScaleBigger()
    {
        this.transform.localScale += new Vector3(1F, 0, 0);
        leftBound = 1.25f;
        rightBound = 14.75f;
    }

    void AutoToggle()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (autoPlay)
            {
                autoPlay = false;
            }
            else {
                autoPlay = true;
            }
        }
    }
}
