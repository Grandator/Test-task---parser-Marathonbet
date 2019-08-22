using Marathonbet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marathonbet.Services.ParseService
{
    public interface IParseService
    {
        Task<List<Match>> GetMatches();
    }
}
