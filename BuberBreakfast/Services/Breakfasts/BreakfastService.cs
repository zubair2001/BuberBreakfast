using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Services.Breakfasts
{
    public class BreakfastService : IBreakfastService
    {
        private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();
        public void CreateBreakfast(Breakfast breakfast)
        {
            _breakfasts.Add(breakfast.Id, breakfast);
        }

        public void DeleteBreakfast(Guid id)
        {
            _breakfasts.Remove(id);
        }

        public ErrorOr<Breakfast> GetBreakfast(Guid id)
        {
            if(_breakfasts.TryGetValue(id, out var breakfast))
            {
                return breakfast;
            }
            return Errors.Breakfast.NotFound;
        }

        public Breakfast UpsertBreakfast(Breakfast breakfast)
        {
            return _breakfasts[breakfast.Id] = breakfast;
        }
    }
}