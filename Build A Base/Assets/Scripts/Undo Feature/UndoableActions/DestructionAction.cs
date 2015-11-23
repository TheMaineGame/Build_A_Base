using UnityEngine;

namespace MaineGame.Utils.Undo {
    public class DesctructionAction : UndoableAction {
        GameObject m_prefab;
        Vector3 m_pos;
        Quaternion m_rot;
        GameObject m_instance;
        /// <summary>
        /// Creates an UndoableAction which destroys a given object.
        /// </summary>
        /// <param name="obj">The object being destroyed.</param>
        /// <param name="prefab">The prefab of the GameObject being destroyed.</param>
        /// <param name="position">The position where the object was at destruction.</param>
        /// <param name="rotation">The rotation of the object at destruction.</param>
        public DesctructionAction (GameObject obj, GameObject prefab, Vector3 position, Quaternion rotation) : base () {
            m_instance = obj;
            m_prefab = prefab;
            m_pos = position;
            m_rot = rotation;
        }

        public override void Redo () {
            m_undone = false;
            UnityEngine.Object.Destroy (m_instance);
        }

        public override void Undo () {
            m_undone = true;
            m_instance = UnityEngine.Object.Instantiate (m_prefab);
            m_instance.transform.position = m_pos;
            m_instance.transform.rotation = m_rot;
        }
    }
}