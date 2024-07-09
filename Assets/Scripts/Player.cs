using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour {
    public float force = 100f;

    public Rigidbody2D rigidbody;

    public Animator animator;

    public bool death;

    public delegate void DeathNotify();

    public event DeathNotify OnDeath;

    private Vector3 initPos;

    public UnityAction<int> OnScore;
    // Use this for initialization
    void Start () {
        this.Idle();
        initPos = this.transform.position;
	}

    public void Init()
    {
        this.Idle();
        this.transform.position = initPos;
        this.death = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.death)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(new Vector2(0,force),ForceMode2D.Force);
        }
	}

    public void Die()
    {
        this.death = true;
        if(this.OnDeath!=null)
        {
            this.OnDeath();
        }
    }

    public void Idle()
    {
        this.rigidbody.simulated = false;
        this.animator.SetTrigger("Idle");
    }
    public void Fly()
    {
        this.rigidbody.simulated = true;
        this.animator.SetTrigger("Fly");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("ScoreArea"))
        {

        }
        else
        {
            Die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("ScoreArea"))
        {
            if (this.OnScore != null)
                this.OnScore(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
}
