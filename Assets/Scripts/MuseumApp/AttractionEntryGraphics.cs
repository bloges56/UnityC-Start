﻿using MuseumApp;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AttractionEntryGraphics : MonoBehaviour
{
    public Image thumbmnail;

    public TMP_Text attractionTitle;
    public TMP_Text attractionLocation;

    public List<Image> stars;
    public Color activeStarColor = new Color(1f, 0.75f, 0f);
    public Color inactiveStarColor = new Color(0.78f, 0.78f, 0.79f);

    public AttractionScreenParameters screenParametersPrefab;

    private AttractionConfig attractionConfig;
    public void OnClick()
    {
        var parametersObject = Instantiate(screenParametersPrefab);
        parametersObject.attractionConfig = attractionConfig;
        SceneManager.LoadScene("AttractionScreen", LoadSceneMode.Single);
    }

    public void Setup(AttractionConfig config)
    {
        attractionConfig= config;

        attractionTitle.text= attractionConfig.title;

        attractionLocation.text= attractionConfig.location;

        SetupThumbnail();
        SetupStars(PlayerPrefs.GetInt(attractionConfig.id));
    }

    private void SetupThumbnail()
    {
        thumbmnail.sprite = attractionConfig.image;
        var rectTransform = thumbmnail.GetComponent<RectTransform>();
        rectTransform.anchoredPosition3D = attractionConfig.thumbnailPostiiton;
        rectTransform.sizeDelta = attractionConfig.thumbnailSize;
    }

    private void SetupStars(int activeStarCount)
    {
        for(int i = 0; i < stars.Count; i++)
        {
            stars[i].color= i < activeStarCount ? activeStarColor : inactiveStarColor;
        }
    }
}
