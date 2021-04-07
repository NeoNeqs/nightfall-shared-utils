namespace SharedUtils.Logging
{
    internal struct Buffer
    {
        public readonly string[] strings;

        public readonly int Size => strings.Length;

        public int position;

        public Buffer(int size)
        {
            strings = new string[size];
            position = 0;
        }

        public string this[int index] => index > Size ? string.Empty : strings[index];

        public void Store(string str)
        {
            strings[position] = str;

            position++;
        }

        public bool Overflows()
        {
            return position + 1 >= Size;
        }

        public void ResetPosition()
        {
            position = 0;
        }
    }
}
