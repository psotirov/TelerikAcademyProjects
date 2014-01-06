using System;

namespace AcademyPopcorn
{
    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true); // the key is not shown on the console
                while (Console.KeyAvailable) Console.ReadKey(true); // empties the keyboard buffer
                if (keyInfo.Key.Equals(ConsoleKey.A) || keyInfo.Key.Equals(ConsoleKey.LeftArrow)) // move left - "A" or "left arrow" 
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.D) || keyInfo.Key.Equals(ConsoleKey.RightArrow)) // move right - "D" or "right arrow" 
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (this.OnActionPressed != null)
                    {
                        this.OnActionPressed(this, new EventArgs());
                    }
                }
            }
        }

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnActionPressed;
    }
}
