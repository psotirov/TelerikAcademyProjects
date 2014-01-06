using System;
using System.Text;

namespace FreeContentCatalog
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output);
    }
}
