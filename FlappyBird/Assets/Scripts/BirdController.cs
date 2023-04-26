using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    GameObject obj;
    GameObject gameController;
    public AudioClip hitClip;
    public AudioClip getPointClip;
    public AudioClip dieClip;
    public AudioClip wingClip;
    private AudioSource audioSource;
    private Animator animator;
    public float flyPower;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        animator = obj.GetComponent<Animator>();
        animator.SetFloat("flyPower", 0);
        animator.SetBool("isDead", false);
        flyPower = 10;
        if (gameController == null) {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!gameController.GetComponent<GameController>().isEndGame) { 
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
                audioSource.clip = wingClip;
                audioSource.Play();
                animator.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }

    void EndGame()
    {
        animator.SetBool("isDead", true);
        audioSource.clip = hitClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag.Equals("Bird"))
            gameController.GetComponent<GameController>().GetPoint();
        audioSource.clip = getPointClip;
        audioSource.Play();
    }

}
