using System.Collections.Generic;
using Aksara.Core;
using UnityEngine;

namespace Aksara.UI
{
    public class ChooseTheLevelButtonUI : MonoBehaviour
    {
        [SerializeField] TypeButtonUI buttonPrefab;
        [SerializeField] Menu destinationMenu;

        public void Redraw(IEnumerable<Difficulty> types) {
            foreach(Transform child in transform) {
                Destroy(child.gameObject);
            }
            foreach(Difficulty type in types) {
                TypeButtonUI instance = Instantiate(buttonPrefab, this.transform);
                instance.SetAksaraType(type);
                instance.SetGoToMenu(destinationMenu);
            }
        }
    }
}