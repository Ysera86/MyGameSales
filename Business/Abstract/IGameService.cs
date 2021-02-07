using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IGameService
    {
        List<Game> GetAllGames();
        Game GetGame(int id);
        void AddGame(Game Game);
        void UpdateGame(Game Game);
        void DeleteGame(Game Game);
    }
}
