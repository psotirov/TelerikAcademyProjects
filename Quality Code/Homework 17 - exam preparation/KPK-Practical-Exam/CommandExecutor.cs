using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeContentCatalog
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder commandOutput)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    contentCatalog.Add(new Content(ContentType.Book, command.Parameters));
                    commandOutput.AppendLine("Books added");
                    break;
                case CommandType.AddMovie:
                    contentCatalog.Add(new Content(ContentType.Movie, command.Parameters));
                    commandOutput.AppendLine("Movie added");
                    break;
                case CommandType.AddSong:
                    contentCatalog.Add(new Content(ContentType.Song, command.Parameters));
                    commandOutput.AppendLine("Song added");
                    break;
                case CommandType.AddApplication:
                    contentCatalog.Add(new Content(ContentType.Application, command.Parameters));
                    commandOutput.AppendLine("Application added");
                    break;
                case CommandType.Update:
                    if (command.Parameters.Length != 2)
                    {
                        throw new FormatException("Invalid params!");
                    }

                    commandOutput.AppendLine(String.Format("{0} items updated",
                        contentCatalog.UpdateContent(command.Parameters[0], command.Parameters[1])));
                    break;
                case CommandType.Find:
                    if (command.Parameters.Length != 2)
                    {
                        throw new Exception("Invalid number of parameters!");
                    }

                    int numberOfElementsToList = int.Parse(command.Parameters[1]);

                    IEnumerable<IContent> foundContent = contentCatalog.GetListContent(command.Parameters[0], numberOfElementsToList);

                    if (foundContent.Count() == 0)
                    {
                        commandOutput.AppendLine("No items found");
                    }
                    else
                    {
                        foreach (IContent content in foundContent)
                        {
                            commandOutput.AppendLine(content.TextRepresentation);
                        }
                    }
                    break;
                default:
                    throw new InvalidCastException("Unknown command!");
            }
        }
    }
}