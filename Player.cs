namespace FootballChampionship.Refactored
{
    public class Player
    {
        public string Name { get; }
        public int Age { get; }
        public double Height { get; }
        public double Weight { get; }
        public bool IsCaptain { get; set; }

        public Player(string name, int age, double height, double weight)
        {
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Имя игрока: {Name}, Возраст: {Age}, Рост: {Height}m, Вес: {Weight}kg");
        }
    }
}