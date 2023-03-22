using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MuseumApp
{
    public class AttractionScreen : MonoBehaviour
    {
        public Image cover;

        public TMP_Text attractionTitle;
        public TMP_Text attractionLocation;
        public TMP_Text attractionAuthor;
        public TMP_Text attractionDescription;

        public List<Image> stars;
        public Color activeStarColor = new Color(1f, 0.75f, 0f);
        public Color inactiveStarColor = new Color(0.78f, 0.78f, 0.79f);

        private AttractionScreenParameters attractionScreenParameters;

        public void OnClickBack()
        {
            Destroy(attractionScreenParameters.gameObject);
            SceneManager.LoadScene("HomeScreen", LoadSceneMode.Single);
        }

        public void OnClickStar(int index)
        {
            PlayerPrefs.SetInt(attractionScreenParameters.attractionConfig.id, index);
            SetupStars(index);
        }

        private void Start()
        {
            attractionScreenParameters = FindObjectOfType<AttractionScreenParameters>();
            var attractionConfig = attractionScreenParameters.attractionConfig;

            attractionTitle.text = attractionConfig.title;
            attractionLocation.text = attractionConfig.location;
            attractionAuthor.text = attractionConfig.author;
            attractionDescription.text = attractionConfig.description;

            SetupCover(attractionConfig);
            SetupStars(PlayerPrefs.GetInt(attractionConfig.id));
        }

        private void SetupCover(AttractionConfig attractionConfig)
        {
            cover.sprite = attractionConfig.image;

            var rectTransform = cover.GetComponent<RectTransform>();
            rectTransform.anchoredPosition3D = attractionConfig.headerImagePosition;
            rectTransform.sizeDelta = attractionConfig.headerImageSize;
        }

        private void SetupStars(int activeStarCount)
        {
            for(int i = 0; i < stars.Count; i++)
            {
                stars[i].color = i < activeStarCount ? activeStarColor : inactiveStarColor;
            }
        }
    }
}