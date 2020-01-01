using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip hitSFX;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
    public static Special special;
    public GameObject smoke;
	public Color brickColour;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
    private bool isSpecial = false;

    // Use this for initialization
    void Start()
    {
        isBreakable = (this.tag == "Breakable");
        if(this.name == "Special")
        {
            isSpecial = true;
            Debug.Log("Special Brick created");
        }
        if (isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        Debug.Log(breakableCount);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(hitSFX, transform.position, 0.2f);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        //SimulateWin();
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            print(brickColour);
            PuffSmoke();
            Destroy(gameObject, 0.05f);
            if (isSpecial)
            {
                SpawnSpecialItem();
            }
        }
        else {
            LoadSprite();
        }
    }

    void SpawnSpecialItem()
    {
        special = GameObject.FindObjectOfType<Special>();
        Debug.Log("Spawn Special Called");
        special.SpawnSpecial(Random.Range(0,3));
    }


    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        brickColour.a = 1;
        smokePuff.GetComponent<ParticleSystem>().startColor = brickColour;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //TODO Remove
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

    void LoadSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else {
            Debug.LogError("Could not load brick sprite");
        }
    }
}
