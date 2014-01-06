using System;

namespace _01_12_GSM
{
    public class Display
    {
        private float _sizeInches; // field for display's size in inches, for example 3.5", 4.0"
        private ulong _nrColors; // field for display's number of colors, for example 65 536, 16 777 216

        public float SizeInches // size property
        {
            get { return _sizeInches; }
            set 
            {
                if (value < 1) throw new ArgumentOutOfRangeException("Invalid DisplaySize"); // the display size cannot be less than 1"
                else _sizeInches = value;
            }
        }
        public ulong NrColors // colors property
        {
            get { return _nrColors; }
            set 
            {
                if (value < 2) throw new ArgumentOutOfRangeException("Invalid DisplayColors"); // the display color cannot be less than 2
                else _nrColors = value;
            }
        }
        public Display() : this(1, 2) // default constructor - minimum display size of 1" and at least 2 colors
        {
        }

        public Display(float size, ulong cols)
        {
            this.SizeInches = size;
            this.NrColors = cols;
        }
    }
}
