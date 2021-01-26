using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

    [Header("Stats")]
    [SerializeField] int health = 100;
    [SerializeField] float velocity = -1f;

    [Header("VFX")]
    [SerializeField] GameObject onCollectedPrefab;
    [SerializeField] float durationOfEffect = 1f;

    [Header("SFX")]
    [SerializeField] AudioClip onCollectedSFX;
    [SerializeField] [Range(0f, 1f)] float collectedSoundVolume = 0.7f;

    // Use this for initialization
    void Start()
    {
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.y = this.velocity;
        velocity.x = 0f;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int Hit()
    {
        Collected();
        Destroy(gameObject);
        return health;
    }

    public int GetValue()
    {
        return health;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    private void Collected()
    {
        CollectedVFX();
        CollectedSFX();
    }

    private void CollectedSFX()
    {
        AudioSource.PlayClipAtPoint(onCollectedSFX, Camera.main.transform.position, collectedSoundVolume);
    }

    private void CollectedVFX()
    {
        GameObject effect = Instantiate(
                    onCollectedPrefab,
                    transform.position,
                    Quaternion.identity) as GameObject;

        Destroy(effect, durationOfEffect);
    }

    
}
