using UnityEngine;
using System.Collections;

public class Special : MonoBehaviour {

    enum SpecialNo { Scale, AddBall, MultiBaLL, StickyPaddle};
    private Ball ball;
    private Paddle paddle;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        Debug.Log(paddle.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnSpecial(int special)
    {
        switch(special)
        {
            case 0:
                paddle.ScaleBigger();
                break;
            case 1:
                ball.StickyBall();
                break;
            case 2:
                ball.addBall();
                break;
            case 3:
                ball.minusBall();
                break;
            default:
                break;
        }
    }
}
