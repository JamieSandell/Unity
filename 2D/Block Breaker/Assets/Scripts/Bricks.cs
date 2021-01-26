using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {
    [SerializeField]
    private Sprite [] hitSprites;
    public Sprite[] HitSprites
    {
        get
        {
            return hitSprites;
        }
        set
        {
            hitSprites = value;
        }
    }

    //[SerializeField]
    private int maxHits;
    private int MaxHits
    {
        get
        {
            return maxHits;
        }
        set
        {
            maxHits = value;
        }
    }

    private LevelManagerController levelManagerController;
    private LevelManagerController LevelManagerController
    {
        get
        {
            return levelManagerController;
        }
        set
        {
            levelManagerController = value;
        }
    }

    private int timesHit;
    private int TimesHit
    {
        get
        {
            return timesHit;
        }
        set
        {
            timesHit = value;
        }
    }

    private static int breakableBrick = 0;
    [SerializeField]
    public static int BreakableBrick
    {
        get
        {
            return breakableBrick;
        }
        set
        {
            breakableBrick = value;
        }
    }
    private bool isBreakable;
    private bool IsBreakable
    {
        get
        {
            return isBreakable;
        }
        set
        {
            isBreakable = value;
        }
    }

    [SerializeField]
    private AudioClip crack;
    public AudioClip Crack
    {
        get
        {
            return crack;
        }
        set
        {
            crack = value;
        }
    }

    [SerializeField]
    private GameObject smoke;
    public GameObject Smoke
    {
        get
        {
            return smoke;
        }
        set
        {
            smoke = value;
        }
    }

	// Use this for initialization
	void Start () {
        MaxHits = HitSprites.Length;
        TimesHit = 0;
        levelManagerController = FindObjectOfType<LevelManagerController>();

        if (this.tag == "Breakable")
        {
            BreakableBrick++;
            IsBreakable = true;
        }
        Debug.Log("Breakable Brick Count: " + BreakableBrick.ToString());

        if (Smoke == null)
        {
            Debug.LogError("Smoke == null");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (TimesHit >= MaxHits)
        {
			PuffSmoke ();

            Debug.Log(gameObject.name + " destroyed.");
            Destroy(gameObject);     
            if (IsBreakable)
            {
                BreakableBrick = BreakableBrick - 1;
                Debug.Log("Breakable Bricks: " + BreakableBrick.ToString());
                levelManagerController.BrickDestroyed();
            }
        }
        else
        {
            LoadSprites();
        }
    }

    private void HandleHits()
    {
        TimesHit++;
        Debug.Log(TimesHit.ToString());
    }

    private void LoadSprites()
    {
        int spriteIndex = TimesHit;
        if (hitSprites[spriteIndex]) //!= null
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError(this.gameObject.name + " expecting a Sprite in LoadSprites().");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }        
    }

	void PuffSmoke()
	{
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

		ParticleSystem particleSystem = Smoke.GetComponent<ParticleSystem>();
		var main = particleSystem.main;
		main.startColor = spriteRenderer.color;


		Smoke.transform.position = this.transform.position;
		Smoke.transform.rotation = Quaternion.identity;
		Object.Instantiate(Smoke);
	}

    // TODO Remove this method once we can actually win
    void SimulateWin()
    {
        Debug.Log("Simulate Win");
        levelManagerController.LoadNextLevel();
    }
}
