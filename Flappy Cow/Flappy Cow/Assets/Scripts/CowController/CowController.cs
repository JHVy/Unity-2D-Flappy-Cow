using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour
{
    public static CowController instance;

    public float bounceForce;

    private Rigidbody2D myBody;

    private Animator ani;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private bool isAlive; // khai bao mac dinh se la false
    private bool didFlap;

    private GameObject spawner;

    public float flag = 0;
    public int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        isAlive = true;
        myBody = GetComponent < Rigidbody2D > ();
        ani = GetComponent < Animator > ();
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
        _CowMoveMent();
    }

    void _CowMoveMent()
    {
            if (isAlive)
            {
                if (didFlap)
                {
                    didFlap = false; // chi cho ng dung nhan vao duy nhat 1 lan :)
                    myBody.velocity = new Vector2(myBody.velocity.x, bounceForce);
                    audioSource.PlayOneShot(flyClip);
                }
 
            }

        if(myBody.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp (0, 90, myBody.velocity.y / 12); // Lerp : tra ve phep toan loai suy giua a va b theo t
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else if (myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (myBody.velocity.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 12); // Lerp : tra ve phep toan loai suy giua a va b theo t
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    // bat su kien cho button : luon viet ham public
    public void FlapButton()
    {
        didFlap = true;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "PipeHolder")
        {
            score++;
            if(GamePlayController.instance != null)
            {
                GamePlayController.instance._SetScore(score);
            }
            audioSource.PlayOneShot(pingClip);
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {
            flag = 1;
            if(isAlive)
            {
                isAlive = false;
                Destroy(spawner);
                audioSource.PlayOneShot(diedClip);
                ani.SetTrigger("Died");
            }
            if(GamePlayController.instance != null)
            {
                GamePlayController.instance._CowDieShowPanel(score);
            }
        }
    }
}
