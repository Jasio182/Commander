using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        // Gives list of all command resources.
        IEnumerable<Command> GetAppComands();
        // Returnes single command based on ID.
        Command GetCommandById(int id);
        // Contract to create something in database.
        void CreateCommand(Command cmd);
        bool SaveChanges();
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}
