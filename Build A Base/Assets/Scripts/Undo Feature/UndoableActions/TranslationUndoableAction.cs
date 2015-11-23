using System;
using UnityEngine;

namespace MaineGame.Utils.Undo {
    public class TranslationUndoableAction : UndoableAction {
        /// <summary>
        /// Creates an UndoableAction representing the move from "from"
        /// to "to".
        /// </summary>
        /// <param name="obj">The GameObject being moved.</param>
        /// <param name="from">The position where the object was at the start of the move.</param>
        /// <param name="to">The position where the object is at the end of the move.</param>
        public TranslationUndoableAction (GameObject obj, Vector3 from, Vector3 to)
            : base (SendToAction(obj, from), SendToAction(obj, to)) { }

        // Utility method for use in properly calling base constructor
        static Action SendToAction (GameObject obj, Vector3 pos) {
            return () => obj.transform.position = pos;
        }
    }
}
