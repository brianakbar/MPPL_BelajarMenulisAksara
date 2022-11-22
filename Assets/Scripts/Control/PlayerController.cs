using UnityEngine;
using UnityEngine.InputSystem;
using Aksara.Draw;
using Aksara.Core;

namespace Aksara.Control {
    public class PlayerController : MonoBehaviour {
        Drawer drawer;
        GameCursor cursor;

        void Awake() {
            drawer = GetComponent<Drawer>();
            cursor = GetComponent<GameCursor>();
        }

        void OnClick(InputValue value) {
            if(value.Get<float>() == 1f) {
                drawer.StartDrawLine();
            }
            else {
                drawer.FinishDrawLine();
            }
        }

        void OnPosition(InputValue value) {
            cursor.Position = value.Get<Vector2>();
        }  
    }   
}