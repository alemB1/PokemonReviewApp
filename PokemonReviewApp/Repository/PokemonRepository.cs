using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    // Dont forget to inherit the interface
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context; // good practice
        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pokemon> GetPokemons() 
        { 
            return _context.Pokemon.OrderBy(p => p.Id).ToList(); // be explicit when returning data
        }
        // return ICollection list ordered by id



    }
}
