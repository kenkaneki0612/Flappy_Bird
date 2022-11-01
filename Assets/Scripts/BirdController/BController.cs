using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BController : MonoBehaviour
{

    public static BController instance;
    public float bounceForce;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private bool isALive;
    private bool didFlap;

    private GameObject spawner;

    public float flag = 0;
    public int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        isALive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _MakeInstance();
        spawner = GameObject.Find("Spawner Pipe");
    }

    void _MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _BirdMoveMent();
    }

    void _BirdMoveMent()
    {

        if(isALive)
        {
            if(didFlap)
            {
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
        }

        if(myBody.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        } else if(myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if(myBody.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    public void FlapButton()
    {
        didFlap = true;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PipeHolder")
        {
            score++;
            if(GPlayControoler.instance != null) {
                GPlayControoler.instance._setScore(score);
            }
            audioSource.PlayOneShot(pingClip);
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {
            flag = 1;

            if (isALive)
            {
                isALive = false;
                Destroy(spawner);
                audioSource.PlayOneShot(diedClip);
                anim.SetTrigger("Died");
            }
            if(GPlayControoler.instance != null) {
                GPlayControoler.instance._BirdDiedShowPanel(score);
            }
        }
    }

}
