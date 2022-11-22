using System.Collections;
using UnityEngine;
using Aksara.Core;

namespace Aksara.Draw {
    public class Drawer : MonoBehaviour {
        [SerializeField] LineRenderer line = null;
        [SerializeField] float lineSeparationDistance = 0.1f;

        Vector3 previousPoint;
        Coroutine drawCoroutine = null;
        GameCursor cursor;

        void Awake() {
            cursor = GetComponent<GameCursor>();
        }

        public void StartDrawLine() {
            if(drawCoroutine != null) StopCoroutine(drawCoroutine);

            drawCoroutine = StartCoroutine(DrawLine());
        }

        public void FinishDrawLine() {
            StopCoroutine(drawCoroutine);
        }

        IEnumerator DrawLine() {
            LineRenderer lineInstance = Instantiate(line, Vector3.zero, Quaternion.identity, 
                                                    gameObject.transform);
            lineInstance.positionCount = 0;

            while(true) {
                Vector3 position = Camera.main.ScreenToWorldPoint(cursor.Position);
                position.z = 0f;

                if(ShouldPlacePoint(position)) {
                    previousPoint = position;
                    lineInstance.positionCount++;
                    lineInstance.SetPosition(lineInstance.positionCount-1, position);
                }

                yield return null;
            }
        }

        bool ShouldPlacePoint(Vector3 point) {
            return Vector3.Distance(point, previousPoint) > lineSeparationDistance;
        }
    }
}