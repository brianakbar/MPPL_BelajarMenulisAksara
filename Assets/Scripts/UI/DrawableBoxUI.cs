using UnityEngine;
using UnityEngine.UI;

namespace Aksara.UI
{
    public class DrawableBoxUI : MonoBehaviour {
        [SerializeField] Image aksaraFill = null;
        [SerializeField] Image aksaraOutline = null;

        public void Setup(Sprite aksaraFillSprite, Sprite aksaraOutlineSprite) {
            if(aksaraFillSprite == null) return;
            aksaraFill.sprite = aksaraFillSprite;

            if(aksaraOutlineSprite == null) return;
            aksaraOutline.sprite = aksaraOutlineSprite;
        }

        public void SetAksaraFill(bool state) {
            aksaraFill.gameObject.SetActive(state);
        }

        public void SetAksaraOutline(bool state) {
            aksaraOutline.gameObject.SetActive(state);
        }
    }
}
