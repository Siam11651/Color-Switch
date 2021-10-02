using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleTextBehaviour : MonoBehaviour
{
    [SerializeField] private float timeInterval;
    private Color[] colors;
    private Text text;
    private int currentInd, nextInd;
    private float startTime, endTime, rAdd, gAdd, bAdd;

    // Start is called before the first frame update
    void Start()
    {
        colors = new Color[] { Color.red, Color.green, Color.blue, Color.yellow };
        currentInd = Random.Range(0, 4);

        ResetNextInd();

        text = GetComponent<Text>();
        text.color = colors[currentInd];
        startTime = endTime = -1;

        ResetAdd();
    }

    // Update is called once per frame
    void Update()
    {
        float rNew = Mathf.Max(Mathf.Min(text.color.r + rAdd * Time.deltaTime, 1), 0);
        float gNew = Mathf.Max(Mathf.Min(text.color.g + gAdd * Time.deltaTime, 1), 0);
        float bNew = Mathf.Max(Mathf.Min(text.color.b + bAdd * Time.deltaTime, 1), 0);

        text.color = new Color(rNew, gNew, bNew);

        if(startTime == -1)
        {
            startTime = Time.time;
        }
        else
        {
            endTime = Time.time;
            float elapsedTime = endTime - startTime;

            if(elapsedTime >= timeInterval)
            {
                startTime = endTime = -1;
                currentInd = nextInd;

                ResetNextInd();
                ResetAdd();
            }
        }
    }

    private void ResetAdd()
    {
        rAdd = (colors[nextInd].r - colors[currentInd].r) / timeInterval;
        gAdd = (colors[nextInd].g - colors[currentInd].g) / timeInterval;
        bAdd = (colors[nextInd].b - colors[currentInd].b) / timeInterval;
    }

    private void ResetNextInd()
    {
        nextInd = Random.Range(0, 3);

        if(nextInd >= currentInd)
        {
            nextInd++;
        }
    }
}
