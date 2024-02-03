using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectorManagerNew : MonoBehaviour
{
    public RectTransform Poster1;
    public RectTransform Poster2;
    public RectTransform Poster3;

    public GameObject tracker;
    public GameObject detector;
    public float threshold;
    public bool isDistanceClose = false;
    public TextMeshProUGUI debugText;

    private bool shouldOnDistanceCloseTrigger = false;
    private bool shouldOnDistanceFarTrigger = false;
    private string hoveredPoster;

    private Vector2 posterSizePressed = new Vector2(2.7f / 2f, 4.8f / 2f);
    private Vector2 posterSizeDefault = new Vector2(2.7f / 1.2f, 4.8f / 1.2f);
    private Vector2 posterSizeHover = new Vector2(2.7f, 4.8f);

    public string pressedPoster = "";

    // Start is called before the first frame update
    //void Start()
    //{
    //}

    // Update is called once per frame
    private void Update()
    {

        debugText.text = hoveredPoster;

        float dist = Vector3.Distance(tracker.transform.position, detector.transform.position);

        if (dist <= threshold)
        {
            shouldOnDistanceFarTrigger = true;

            if (shouldOnDistanceCloseTrigger)
            {
                isDistanceClose = true;
                if (hoveredPoster == "poster1")
                {
                    Poster1.sizeDelta = posterSizePressed;
                }
                else if (hoveredPoster == "poster2")
                {
                    Poster2.sizeDelta = posterSizePressed;
                }
                else if (hoveredPoster == "poster3")
                {
                    Poster3.sizeDelta = posterSizePressed;
                }
                shouldOnDistanceCloseTrigger = false;
            }
        }
        else
        {
            shouldOnDistanceCloseTrigger = true;
            if (shouldOnDistanceFarTrigger)
            {
                isDistanceClose = false;

                // Parse the selected poster data to external
                pressedPoster = hoveredPoster;

                if (hoveredPoster == "poster1")
                {
                    pressedPoster = hoveredPoster;
                    Poster1.sizeDelta = posterSizeHover;
                }
                else if (hoveredPoster == "poster2")
                {
                    Poster2.sizeDelta = posterSizeHover;
                }
                else if (hoveredPoster == "poster3")
                {
                    Poster3.sizeDelta = posterSizeHover;
                }
                shouldOnDistanceFarTrigger = false;
            }
        }
    }

    private void Start()
    {
        Poster1.sizeDelta = posterSizeDefault;
        Poster2.sizeDelta = posterSizeDefault;
        Poster3.sizeDelta = posterSizeDefault;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "poster1")
        {
            hoveredPoster = other.tag;
            Poster1.sizeDelta = posterSizeHover;
            Poster2.sizeDelta = posterSizeDefault;
            Poster3.sizeDelta = posterSizeDefault;
        }
        else if (other.tag == "poster2")
        {
            hoveredPoster = other.tag;
            Poster1.sizeDelta = posterSizeDefault;
            Poster2.sizeDelta = posterSizeHover;
            Poster3.sizeDelta = posterSizeDefault;
        }
        else if (other.tag == "poster3")
        {
            hoveredPoster = other.tag;
            Poster1.sizeDelta = posterSizeDefault;
            Poster2.sizeDelta = posterSizeDefault;
            Poster3.sizeDelta = posterSizeHover;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isDistanceClose == false)
        {
            hoveredPoster = "";
            Poster1.sizeDelta = posterSizeDefault;
            Poster2.sizeDelta = posterSizeDefault;
            Poster3.sizeDelta = posterSizeDefault;
        }
    }
}
