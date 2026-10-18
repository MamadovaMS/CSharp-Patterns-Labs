namespace Lab2_CommandTextEditor
{
    public class TextEditor
    {
        public string Text { get; set; }
        public string Clipboard { get; set; }

        public TextEditor(string initialText = "")
        {
            Text = initialText;
            Clipboard = "";
        }

        public void Copy(int from, int to)
        {
            if (from < 0) from = 0;
            if (to > Text.Length) to = Text.Length;
            if (from >= to)
            {
                Clipboard = "";
                return;
            }
            Clipboard = Text.Substring(from, to - from);
        }

        public void Paste(int position)
        {
            if (string.IsNullOrEmpty(Clipboard)) return;
            if (position < 0) position = 0;
            if (position > Text.Length) position = Text.Length;
            Text = Text.Insert(position, Clipboard);
        }

        public void Insert(int position, string str)
        {
            if (position < 0) position = 0;
            if (position > Text.Length) position = Text.Length;
            Text = Text.Insert(position, str);
        }

        public void Delete(int from, int to)
        {
            if (from < 0) from = 0;
            if (to > Text.Length) to = Text.Length;
            if (from >= to) return;
            Text = Text.Remove(from, to - from);
        }
    }
}