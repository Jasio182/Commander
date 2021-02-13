using Commander.Models;
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
        public IEnumerable<Command> GetAppComands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            // Gets an object named command, where Id of command equals id from parameter. Lambda expression.
            return _context.Commands.FirstOrDefault(command => command.Id == id);
        }
    }
}
