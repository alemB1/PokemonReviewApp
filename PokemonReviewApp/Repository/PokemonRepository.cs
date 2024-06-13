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

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(r => r.Id == pokeId).ToList();
            if (review.Count() <= 0) {
                return 0;
            }
            return ((decimal)review.Sum(r => r.Rating)/ review.Count());
        }

        public ICollection<Pokemon> GetPokemons() 
        { 
            return _context.Pokemon.OrderBy(p => p.Id).ToList(); // be explicit when returning data
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p => p.Id == pokeId);
        }
        // return ICollection list ordered by id


    }
}
