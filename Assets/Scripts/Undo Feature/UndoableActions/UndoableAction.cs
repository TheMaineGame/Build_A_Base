using System;

namespace MaineGame.Utils.Undo {
    /// <summary>
    /// Represents a single undoable action of indeterminate type.
    /// Mostly useful for being overridden for more specific actions.
    /// </summary>
    public class UndoableAction : IUndoable {
        /// <summary>
        /// Tells if the current Action can be redone.
        /// Attempting to redo while this is false will
        /// result in an exception being raised.
        /// </summary>
        public bool CanRedo {
            get {
                return m_undone;
            }
        }
        /// <summary>
        /// Tells if the current Action can be undone.
        /// Attempting to undo while this is false will
        /// result in an exception being raised.
        /// </summary>
        public bool CanUndo {
            get {
                return !m_undone;
            }
        }
        // Tells whether the object has been undone.
        // Used in determining CanRedo & CanUndo
        protected bool m_undone = false;
        readonly string kExceptionFormat = "Attempted to {0} an operation that was already {1}.";
        /// <summary>
        /// Redoes the action.
        /// Raises an InvalidOperationException if already redone.
        /// </summary>
        public virtual void Redo () {
            if (CanRedo) {
                m_RedoAction ();
                m_undone = false;
            }
            else throw new InvalidOperationException (string.Format(kExceptionFormat, "redo", "redone"));
        }
        /// <summary>
        /// Equivalent to Redo for actions.
        /// </summary>
        public virtual void Rewind () {
            Redo ();
        }
        /// <summary>
        /// Undoes the action.
        /// Raises an InvalidOperationException is already undone.
        /// </summary>
        public virtual void Undo () {
            if (CanUndo) {
                m_UndoAction ();
                m_undone = true;
            }
            else throw new InvalidOperationException (string.Format (kExceptionFormat, "undo", "undone"));
        }
        /// <summary>
        /// Equivalent to Undo for actions.
        /// </summary>
        public virtual void Unwind () {
            Undo ();
        }
        // Action called when Undo() is called
        protected readonly Action m_UndoAction;
        // Action called when Redo() is called
        protected readonly Action m_RedoAction;
        /// <summary>
        /// Creates an UndoableAction with the given Actions.
        /// </summary>
        /// <param name="undo">The action performed when Undo() is called. Should invert redo</param>
        /// <param name="redo">The action performed when Redo() is called. Should invert undo</param>
        public UndoableAction (Action undo, Action redo) {
            m_UndoAction = undo;
            m_RedoAction = redo;
        }
        /// <summary>
        /// No-args UndoableAction constructor for derived classes to use if they must
        /// alter the standard "Action" structure
        /// </summary>
        public UndoableAction() { }
    }
}
