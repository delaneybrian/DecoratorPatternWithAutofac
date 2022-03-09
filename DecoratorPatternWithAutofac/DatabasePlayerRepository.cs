namespace DecoratorPatternWithAutofac
{
    internal class DatabasePlayerRepository : IPlayerRepository
    {
        private readonly Dictionary<int, Player> _players = new()
        {
            {
                3,
                new Player()
                {
                    FirstName = "Harry",
                    LastName = "Hansen",
                    Age = 23
                }
            },
            {
                4,
                new Player()
                {
                    FirstName = "Rebecca",
                    LastName = "Robson",
                    Age = 45
                }
            }
        };

        public Player GetById(int id)
        {
            if (_players.TryGetValue(id, out var player))
            {
                Console.WriteLine($"Player {id} retrieved from database");
                return player;
            }

            return null;
        }
    }
}
