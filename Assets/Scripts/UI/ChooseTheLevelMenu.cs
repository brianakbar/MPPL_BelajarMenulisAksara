using System.Collections;
using System.Collections.Generic;
using Aksara.Setting;
using UnityEngine;

namespace Aksara.UI {
    public class ChooseTheLevelMenu : Menu {
        [SerializeField] ChooseTheLevelButtonUI buttons;

        GameSetting gameSetting;

        void Awake() {
            gameSetting = FindObjectOfType<GameSetting>();
        }

        void OnEnable() {
            buttons.Redraw(gameSetting.GetAksaraTypes());
        }
    }
}