using UnityEngine;
using UnityEngine.EventSystems;

namespace MaineGame.Utils.Undo {
    public class MovementLogger : MonoBehaviour,
        IInitializePotentialDragHandler, IEndDragHandler {
        [SerializeField]
        UndoGroup m_manager;

        Vector3 beforeDragPosition;

        public void OnInitializePotentialDrag (PointerEventData eventData) {
            beforeDragPosition = gameObject.transform.position;
        }

        public void OnEndDrag (PointerEventData eventData) {
            if (transform.position != beforeDragPosition) {
                m_manager.Register (
                    new TranslationUndoableAction (
                        gameObject,
                        beforeDragPosition,
                        transform.position
                        )
                    );
            }
        }

        // Use this for initialization
        void Start () {
            if (m_manager == null) {
                Debug.LogError ("Manager object is missing", gameObject);
            }
        }
    }
}
