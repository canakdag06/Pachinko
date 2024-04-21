using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform rightLimit;
    [SerializeField] private Transform leftLimit;
    [SerializeField] private UIManager UIManager;

    private Rigidbody2D rb;
    private bool isMovingRight;
    private bool isWin;

    void Start()
    {
        StartCoroutine("Fall");
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("Fall");
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Finish")
        {
            isWin = true;
            UIManager.FinalState(isWin);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            if(!isWin)
            {
                UIManager.FinalState(isWin);
            }
        }
    }

    private IEnumerator Fall()
    {
        while (true)
        {
            if (isMovingRight)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            if (transform.position.x > rightLimit.position.x)
            {
                isMovingRight = false;
            }

            if (transform.position.x < leftLimit.position.x)
            {
                isMovingRight = true;
            }

            yield return null;
        }
    }
}
