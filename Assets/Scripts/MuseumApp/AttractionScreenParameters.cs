using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuseumApp
{
    public class AttractionScreenParameters : MonoBehaviour
    {
        public AttractionConfig attractionConfig;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

