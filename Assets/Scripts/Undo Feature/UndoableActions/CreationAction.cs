using UnityEngine;

namespace MaineGame.Utils.Undo {
    public class CreationAction : UndoableAction {
        GameObject m_prefab;
        Vector3 m_pos;
        Quaternion m_rot;
        GameObject m_instance;
        /// <summary>
        /// Creates an UndoableAction which creates a given object from prefab.
        /// </summary>
        /// <param name="obj">The GameObject that has been created.</param>
        /// <param name="prefab">The GameObject prefab being created.</param>
        /// <param name="position">The position where the object was at creation.</param>
        /// <param name="rotation">The rotation of the object at destruction.</param>
        public CreationAction (GameObject obj, GameObject prefab, Vector3 position, Quaternion rotation) : base() {
            m_instance = obj;
            m_prefab = prefab;
            m_pos = position;
            m_rot = rotation;
        }

        public override void Undo () {
            m_undone = true;
            UnityEngine.Object.Destroy (m_instance);
        }

        public override void Redo () {
            m_undone = false;
            m_instance = UnityEngine.Object.Instantiate (m_prefab);
            m_instance.transform.position = m_pos;
            m_instance.transform.rotation = m_rot;
        }
    }
}
