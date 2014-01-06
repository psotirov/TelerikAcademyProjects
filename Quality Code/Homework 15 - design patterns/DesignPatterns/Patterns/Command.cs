using System;

namespace Patterns
{
    class Command
    {
        class Invoker
        {
            private ACommand command;
            public void SetCommand(ACommand command)
            {
                this.command = command;
            }

            public void ExecuteCommand()
            {
                command.Execute();
            }
        }

        class Receiver
        {
            public void Action()
            {
                // Do some action
            }
        }

        abstract class ACommand
        {
            protected Receiver receiver;
            public ACommand(Receiver receiver)
            {
                this.receiver = receiver;
            }
            public abstract void Execute();
        }

        class ConcreteCommand : ACommand
        {
            public ConcreteCommand(Receiver receiver)
                : base(receiver)
            {
            }

            public override void Execute()
            {
                receiver.Action();
            }
        }

        public void CommandExample()
        {
            Receiver receiver = new Receiver();
            ACommand command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }


    }
}
