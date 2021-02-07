using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class GameManager : IGameService
    {
        IGameDAL _gameDAL;

        public GameManager(IGameDAL gameDAL)
        {
            _gameDAL = gameDAL;
        }
        public void AddGame(Game game)
        {
            _gameDAL.Add(game);
        }

        public void DeleteGame(Game game)
        {
            _gameDAL.Delete(game);
        }

        public List<Game> GetAllGames()
        {
            return _gameDAL.GetEntities();
        }

        public Game GetGame(int id)
        {
            return _gameDAL.GetEntity(g => g.Id == id);
        }

        public void UpdateGame(Game game)
        {
            _gameDAL.Update(game);
        }
    }
}
