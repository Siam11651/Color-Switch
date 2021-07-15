using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] private SceneManager sceneManager;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float upVelocity, targetGravityScale;
    [SerializeField] private Text scoreText;
    private int colorCode;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2D;

    private void ChangeColor()
    {
        int newVal = Random.Range(0, 3);

        if(colorCode > newVal)
        {
            colorCode = newVal;
        }
        else
        {
            colorCode = newVal + 1;
        }

        spriteRenderer.sprite = sprites[colorCode];
    }

    public void BallJump()
    {
        if(!GameManager.paused)
        {
            rb2D.gravityScale = targetGravityScale;
            rb2D.velocity = new Vector2(0, upVelocity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        colorCode = Random.Range(0, 4);
        spriteRenderer.sprite = sprites[colorCode];
    }

    // Update is called once per frame
    void Update()
    {
        float cameraPositionY = Camera.main.transform.position.y;
        float deepestDepth = Camera.main.ScreenToWorldPoint(new Vector2(0, 
            Camera.main.pixelHeight)).y + gameObject.GetComponent<CircleCollider2D>().
            radius * 2;

        if(transform.position.y < cameraPositionY - deepestDepth)
        {
            GameManager.GameOver(sceneManager);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string otherTag = other.gameObject.tag;

        if (otherTag.Equals("Star"))
        {
            scoreText.text = (++sceneManager.score).ToString();

            ChangeColor();
            Destroy(other.gameObject);
        }
        else if(otherTag.Equals("Obstacle"))
        {
            if(other.name.Equals("Red") && colorCode != 0)
            {
                GameManager.GameOver(sceneManager);
            }
            else if(other.name.Equals("Green") && colorCode != 1)
            {
                GameManager.GameOver(sceneManager);
            }
            else if(other.name.Equals("Blue") && colorCode != 2)
            {
                GameManager.GameOver(sceneManager);
            }
            else if(other.name.Equals("Yellow") && colorCode != 3)
            {
                GameManager.GameOver(sceneManager);
            }
        }
    }
}
