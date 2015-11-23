namespace MaineGame.Utils {
    public interface IUndoGroup<U> : IUndoable where U : IUndoable {
        /// <summary>
        /// Registers an IUndoable into the UndoGroup
        /// </summary>
        /// <param name="action">The IUndoable to undo</param>
        void Register (U action);
    }
}
