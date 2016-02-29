using UnityEngine;
using System;
using System.Collections.Generic;

namespace MaineGame.Utils.Undo {
    [CreateAssetMenu(fileName = "Undo Manager", menuName = "Undo Manager", order = 201)]
    public class UndoGroup : ScriptableObject, IUndoGroup<UndoableAction> {
        /// <summary>
        /// Says whether the UndoGroup can be redone.
        /// Trying to call Redo() while this is false
        /// will result in an exception being thrown.
        /// </summary>
        public bool CanRedo {
            get {
                return m_RedoStack.Count != 0;
            }
        }
        /// <summary>
        /// Says whether the UndoGroup can be undone.
        /// Trying to call Undo() while this is false
        /// will result in an exception being thrown.
        /// </summary>
        public bool CanUndo {
            get {
                return m_UndoStack.Count != 0;
            }
        }
        /// <summary>
        /// Redoes the last undone action.
        /// If there is nothing to redo, calling
        /// this will result in an error; check with
        /// the CanRedo property before calling.
        /// </summary>
        public void Redo () {
            try {
                UndoableAction act = m_RedoStack.Pop ();
                act.Redo ();
                m_UndoStack.Push (act);
            }
            catch (InvalidOperationException ioe) {
                throw new InvalidOperationException ("Could not perform redo: Nothing to redo", ioe);
            }
        }
        /// <summary>
        /// Registers an action into the UndoGroup.
        /// Calling this will also clear the Redo stack,
        /// meaning any undone changes cannot be redone.
        /// </summary>
        /// <param name="action"></param>
        public void Register (UndoableAction action) {
            m_RedoStack.Clear ();
            m_UndoStack.Push (action);
        }

        /// <summary>
        /// Redoes every action currently in the redo stack.
        /// Will not change anything if there is nothing to
        /// redo.
        /// </summary>
        public void Rewind () {
            while (CanRedo) {
                Redo ();
            }
        }


        /// <summary>
        /// Undoes the last action.
        /// If there is nothing to undo, calling this will
        /// raise an exception. Check with the CanUndo
        /// property before attempting.
        /// </summary>
        public void Undo () {
            try {
                UndoableAction act = m_UndoStack.Pop ();
                act.Undo ();
                m_UndoStack.Push (act);
            }
            catch (InvalidOperationException ioe) {
                throw new InvalidOperationException ("Could not perform undo: Nothing to undo", ioe);
            }
        }

        /// <summary>
        /// Undoes every action currently in the undo stack.
        /// Will not change anything if there is nothing to
        /// undo.
        /// </summary>
        public void Unwind () {
            while (CanUndo) {
                Undo ();
            }
        }

        /// <summary>
        /// The stack of actions which CAN BE undone
        /// </summary>
        Stack<UndoableAction> m_UndoStack;
        /// <summary>
        /// The stack of actions which CAN BE redone
        /// </summary>
        Stack<UndoableAction> m_RedoStack;

        /// <summary>
        /// Creates a fresh UndoGroup with no actions within.
        /// </summary>
        public UndoGroup () {
            m_UndoStack = new Stack<UndoableAction> ();
            m_RedoStack = new Stack<UndoableAction> ();
        }
    }
}
