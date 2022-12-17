using UnityEngine;
using UnityEngine.UI;

namespace Aksara.UI {
    public class SliderControlButton : MonoBehaviour {
        [SerializeField] Slider slider = null;
        [SerializeField][Range(-100, 100)] float changeValue = 5f;

        Button button;

        void Awake() {
            button = GetComponent<Button>();
        }

        void OnEnable() {
            button.onClick.AddListener(ChangeSliderValue);
        }

        void OnDisable() {
            button.onClick.RemoveListener(ChangeSliderValue);
        }

        void ChangeSliderValue() {
            slider.value += changeValue / 100;
        }
    }
}
