﻿using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class FailScreenView : MonoBehaviour
    {
        [SerializeField] private Button _repeatLvlButton;
        public Button RepeatLvlBtn => _repeatLvlButton;
    }
}