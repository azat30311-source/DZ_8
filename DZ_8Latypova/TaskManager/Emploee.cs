
namespace DZ_8Latypova
{
    internal abstract class Emploee
    {
        public string Name { get; set; }
        public Post Post { get; set; }

        public Emploee(string name, Post post)
        {
            Name = name;
            Post = post;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Сотрудник: {Name}, Должность: {Post}");
        }
    }
}
