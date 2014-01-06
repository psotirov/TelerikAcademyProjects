using System;

namespace AcademyPopcorn
{
    public interface IUserInterface
    {
        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnActionPressed;

        void ProcessInput();
    }
}
