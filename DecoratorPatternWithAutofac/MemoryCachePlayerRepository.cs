namespace DecoratorPatternWithAutofac
{
    internal class MemoryCachePlayerRepository : IPlayerRepository
    {
        private readonly IPlayerRepository _innerPlayerRepository;

        private readonly Dictionary<int, Player> _players = new()
        {
            {
                1,
                new Player()
                {
                    FirstName = "Brian",
                    LastName = "Jones",
                    Age = 37
                }
            },
            {
                2,
                new Player()
                {
                    FirstName = "Kate",
                    LastName = "Johnson",
                    Age = 24
                }
            }
        };

        public MemoryCachePlayerRepository(IPlayerRepository innerplayerRepository)
        {
            _innerPlayerRepository = innerplayerRepository;
        }

        public Player GetById(int id)
        {
            if (_players.TryGetValue(id, out var player))
            {
                Console.WriteLine($"Player {id} retrieved from cache");
                return player;
            }

            return _innerPlayerRepository.GetById(id);
        }
    }
}
