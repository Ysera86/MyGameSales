using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class IMGameDAL_ : IGameDAL
    {
        List<Game> _games;
        public IMGameDAL_()
        {
            _games = new List<Game>
            {
                new Game{ Id=1, Name="GameName1", Genre="Horror", Price= 12},
                new Game{ Id=2, Name="GameName2", Genre="Romance", Price= 11.5M},
                new Game{ Id=3, Name="GameName3", Genre="Horror, Romance", Price= 33},
                new Game{ Id=4, Name="GameName4", Genre="Horror, Comedy", Price= 12.1M}
            };
        }
        public void Add(Game entity)
        {
            _games.Add(entity);
        }

        public void Delete(Game entity)
        {
            _games.Remove(_games.SingleOrDefault(x => x.Id == entity.Id));
        }

        public List<Game> GetEntities(Expression<Func<Game, bool>> filter = null)
        {
            return filter == null ? _games : _games.Where(filter.Compile()).ToList();
        }

        public Game GetEntity(Expression<Func<Game, bool>> filter)
        {
            return _games.SingleOrDefault(filter.Compile());
        }

        public void Update(Game entity)
        {
            var gameToUpdate = _games.SingleOrDefault(x => x.Id == entity.Id);
            gameToUpdate.Genre = entity.Genre;
            gameToUpdate.Name = entity.Name;
            gameToUpdate.Price = entity.Price;
        }
    }
}
