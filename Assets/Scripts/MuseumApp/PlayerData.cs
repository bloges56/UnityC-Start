﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuseumApp
{
    public class PlayerData
    {
        public static string playerDataSaveKey = "playerDataSaveKey";

        public string username;

        //Don't ever store passwords like this
        public string password;
    }
}

