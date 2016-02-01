using System;
using UnityEngine;

namespace MaineGame.Utils.Undo {
    public class RotationUndoableAction : UndoableAction {
        /// <summary>
        /// Creates an UndoableAction representing the rotation from "from"
        /// to "to".
        /// </summary>
        /// <param name="obj">The GameObject being moved.</param>
        /// <param name="from">The position where the object was at the start of the move.</param>
        /// <param name="to">The position where the object is at the end of the move.</param>
        public RotationUndoableAction (GameObject obj, Quaternion from, Quaternion to)
            : base (RotateToAction (obj, from), RotateToAction (obj, to)) { }

        // Utility method for use in properly calling base constructor
        static Action RotateToAction (GameObject obj, Quaternion rotation) {
            return () => obj.transform.rotation = rotation;
        }
    }
}
