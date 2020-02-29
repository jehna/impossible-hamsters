using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public float lift = 0.2f;
    public float penaltyLift = 0.2f;
    public float unlift = 0.005f;
    private bool isActive = false;
    public float maxKiteHeight = 10.0f;
    public float windEffectOnKite = 5.0f;
    private Vector3 previousPosition;
    public Renderer activityIndicator;

    public SpringJoint springJoint;

    public AudioSource[] hitSounds;

    private Wind wind;

    public bool selectable = false;
    private ParticleSystemRenderer psr;

    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        wind = FindObjectOfType<Wind>();
        previousPosition = transform.position;

        hitSounds = GetComponents<AudioSource>();

        ps = GetComponent<ParticleSystem>();
        psr = GetComponent<ParticleSystemRenderer>();
        psr.material.color = new Color(255, 255, 255);
    }

    public void SetIsActive(bool _isActive)
    {
        this.isActive = _isActive;
        activityIndicator.enabled = _isActive;
        ps.Play();
    }

    // Update is called once per frame
    void Update()
    {
        this.springJoint.connectedAnchor += Vector3.down * unlift;

        float deltaX = this.GetComponent<Rigidbody>().velocity.x / speed;

        if (deltaX < 0)
        {
            if (wind.direction > 0)
            {
                this.springJoint.connectedAnchor = Vector3.up * Mathf.Min(lift * Mathf.Abs(wind.direction) * Mathf.Abs(deltaX) + this.springJoint.connectedAnchor.y, this.maxKiteHeight);
            }
            else
            {
                this.springJoint.connectedAnchor += Vector3.down * penaltyLift;
            }
        }
        else if (deltaX > 0)
        {
            if (wind.direction < 0)
            {
                this.springJoint.connectedAnchor = Vector3.up * Mathf.Min(lift * Mathf.Abs(wind.direction) * Mathf.Abs(deltaX) + this.springJoint.connectedAnchor.y, this.maxKiteHeight);
            }
            else
            {
                this.springJoint.connectedAnchor += Vector3.down * penaltyLift;
            }
        }

        if (isActive)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.GetComponent<Rigidbody>().velocity = Vector3.left * speed;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            }
        }
        else
        {
            ps.Stop();
        }

        this.springJoint.connectedAnchor = this.springJoint.connectedAnchor + new Vector3(-this.springJoint.connectedAnchor.x + wind.direction * windEffectOnKite, 0, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            this.selectable = true;
            AudioSource hitSound = hitSounds[Random.Range(0, hitSounds.Length)];
            hitSound.Play();
        }

        if (collision.gameObject.GetComponent<Player>() != null && this.isActive)
        {
            AudioSource hitSound = hitSounds[Random.Range(0, hitSounds.Length)];
            hitSound.Play();
        }
    }
}
