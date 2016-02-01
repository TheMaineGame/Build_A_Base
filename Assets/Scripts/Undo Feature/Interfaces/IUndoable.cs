namespace MaineGame.Utils {
    public interface IUndoable {
        /// <summary>
        /// Undoes the previous action.
        /// </summary>
        void Undo ();

        /// <summary>
        /// Redoes the last undo.
        /// </summary>
        void Redo ();

        /// <summary>
        /// Undoes all undoable actions in the object.
        /// </summary>
        void Unwind ();

        /// <summary>
        /// Redoes all redoable actions in the object.
        /// </summary>
        void Rewind ();

        /// <summary>
        /// Returns a bool stating whether the object can undo or not.
        /// </summary>
        bool CanUndo { get; }

        /// <summary>
        /// returns a bool stating whether the object can redo or not.
        /// </summary>
        bool CanRedo { get; }
    }
}
