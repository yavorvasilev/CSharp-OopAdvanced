using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IManager
{
    string AddHero(List<String> arguments);

    string AddItemToHero(List<String> arguments);

    //string CreateGame();

    string Inspect(List<String> arguments);

    string AddRecipeToHero(List<string> arguments);

    string Quit();

}
