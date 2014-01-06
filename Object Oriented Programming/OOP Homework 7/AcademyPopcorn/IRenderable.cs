using System;

namespace AcademyPopcorn
{
    public interface IRenderable
    {
        MatrixCoords GetTopLeft();

        char[,] GetImage();
    }
}
