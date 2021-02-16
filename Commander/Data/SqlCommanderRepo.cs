using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;
        // Constructor using for Dependency Injection
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));
            // Adding command is not enough to add data to database.
            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAppComands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            // Gets an object named command, where Id of command equals id from parameter. Lambda expression.
            return _context.Commands.FirstOrDefault(command => command.Id == id);
        }

        public bool SaveChanges()
        {
            // Data in database won't be changed, without calling this method.
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //nothing
        }
    }
}
