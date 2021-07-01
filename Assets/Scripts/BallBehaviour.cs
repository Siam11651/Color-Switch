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
        rb2D.gravityScale = targetGravityScale;
        rb2D.velocity = new Vector2(0, upVelocity);
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
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Star"))
        {
            scoreText.text = (++sceneManager.score).ToString();

            ChangeColor();
            Destroy(other.gameObject);
        }
    }
}
