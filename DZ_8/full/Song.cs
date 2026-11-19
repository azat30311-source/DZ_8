

namespace DZ_8
{
    public class Song
    {
        private string _name;
        private string _author;
        private Song _previousSong;
        public Song()
        {
            _name = "Без названия";
            _author = "Неизвестен";
            _previousSong = null;
        }

        public Song(string name, string author)
        {
            _name = name;
            _author = author;
            _previousSong = null;
        }

        public Song(string name, string author, Song previousSong)
        {
            _name = name;
            _author = author;
            _previousSong = previousSong;
        }

        public void SetName(string name) => _name = name;
        public void SetAuthor(string author) => _author = author;
        public void SetPreviousSong(Song prev) => _previousSong = prev;

        public string Title() => $"{_author} - {_name}";

        public override bool Equals(object d)
        {
            if (d is Song otherSong)
            {
                return this._name == otherSong._name && this._author == otherSong._author;
            }
            return false;
        }

        public void PrintSongInfo()
        {
            string prevTitle = _previousSong != null ? _previousSong._name : "отсутствует";
            Console.WriteLine($"Песня: \"{_name}\" | Автор: {_author} | Предыдущая песня: {prevTitle}");
        }
    }
}