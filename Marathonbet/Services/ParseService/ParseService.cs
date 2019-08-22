using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Marathonbet.Data;
using Marathonbet.Models;
using Marathonbet.Services.HttpClientFactory;
using Newtonsoft.Json;

namespace Marathonbet.Services.ParseService
{
    public class ParseService : IParseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        private List<League> Leagues = new List<League> { };
        private List<Match> Matches = new List<Match> { };

        public ParseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
        }

        private List<Event> GetEvents(FluffyChild fluffyChild)
        {
            List<Event> events = new List<Event> { };

            if (fluffyChild.Event != null)
            {
                events.Add(fluffyChild.Event);
            }

            if (fluffyChild.CatInfo != null && fluffyChild.CatInfo.Children != null)
            {
                foreach (FluffyChild child in fluffyChild.CatInfo.Children)
                {
                    events.AddRange(GetEvents(child));
                }
            }

            return events;
        }

        private async Task<string> GetAsync(string url)
        {
            HttpResponseMessage response = _httpClient.GetAsync(url).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "";
                }
            }
        }

        public async Task<List<Match>> GetMatches()
        {
            string result = await GetAsync("https://mobile.marathonbet.com/mobile-gate/api/v1/events/live-sports");

            List<RootObject> sports = JsonConvert.DeserializeObject<List<RootObject>>(result);
            RootObject sportFootball = sports.First(t => t.Name == "Football");

            result = await GetAsync(string.Format("https://mobile.marathonbet.com/mobile-gate/api/v1/events/sport-categories?tree-id={0}", sportFootball.TreeId));
            RootObject leagueObjects = JsonConvert.DeserializeObject<RootObject>(result);

            foreach (FluffyChild purpleChild in leagueObjects.CatInfo.Children)
            {
                foreach (FluffyChild fluffyChild in purpleChild.CatInfo.Children)
                {
                    League tempLeague = new League { };
                    tempLeague.Name = fluffyChild.Name;
                    tempLeague.Id = fluffyChild.TreeId;
                    Leagues.Add(tempLeague);
                }
            }

            foreach (League league in Leagues)
            {
                result = await GetAsync(string.Format("https://mobile.marathonbet.com/mobile-gate/api/v1/events/tree-item-with-children?tree-id={0}", league.Id));
                RootObject matchObject = JsonConvert.DeserializeObject<RootObject>(result);

                if (matchObject != null && matchObject.CatInfo != null)
                {
                    foreach (FluffyChild fluffyChild in matchObject.CatInfo.Children)
                    {
                        List<Event> evs = GetEvents(fluffyChild);

                        foreach (Event ev in evs)
                        {
                            if (ev != null)
                            {
                                double tempWin1;
                                double tempDraw;
                                double tempWin2;
                                double Win1Denominator;
                                double DrawDenominator;
                                double Win2Denominator;
                                double Win1Numerator;
                                double DrawNumerator;
                                double Win2Numerator;
                                Match tempMatch = new Match { };
                                tempMatch.Id = ev.EventId;
                                tempMatch.Url = string.Format("https://mobile.marathonbet.com/live-event/{0}", ev.TreeId);
                                string[] teamNames = (ev.Name).Split();
                                tempMatch.Team1 = new Models.Team { Name = ev.HomeTeam.Members[0].MemberName };
                                tempMatch.Team2 = new Models.Team { Name = ev.AwayTeam.Members[0].MemberName };
                                string[] scores = (ev.Result).Split(new char[] { ':' });
                                tempMatch.Team1Score = Convert.ToInt32(scores[0]);
                                string[] kostul = scores[1].Split();
                                tempMatch.Team2Score = Convert.ToInt32(kostul[0]);
                                tempMatch.Time = ev.MatchTimeInfo.TimeString;
                                if (ev.MainMarket != null &&
                                        ev.MainMarket.Selections != null)
                                {

                                    if (ev.MainMarket.Selections.MatchResult1 != null &&
                                        ev.MainMarket.Selections.MatchResult1.Coefficient != null &&
                                        ev.MainMarket.Selections.MatchResult1.Coefficient.Price != null &&
                                        ev.MainMarket.Selections.MatchResult1.Coefficient.Price.Denominator != 0 &&
                                        ev.MainMarket.Selections.MatchResult1.Coefficient.Price.Numerator != 0)
                                    {
                                        Win1Denominator = ev.MainMarket.Selections.MatchResult1.Coefficient.Price.Denominator;
                                        Win1Numerator = ev.MainMarket.Selections.MatchResult1.Coefficient.Price.Numerator;
                                        tempWin1 = (Win1Denominator + Win1Numerator) / Win1Denominator;
                                    }
                                    else
                                    {
                                        tempWin1 = 0;
                                    }
                                    if (ev.MainMarket.Selections.MatchResultDraw != null &&
                                        ev.MainMarket.Selections.MatchResultDraw.Coefficient != null &&
                                        ev.MainMarket.Selections.MatchResultDraw.Coefficient.Price != null &&
                                        ev.MainMarket.Selections.MatchResultDraw.Coefficient.Price.Denominator != 0 &&
                                        ev.MainMarket.Selections.MatchResultDraw.Coefficient.Price.Numerator != 0)
                                    {
                                        DrawDenominator = ev.MainMarket.Selections.MatchResultDraw.Coefficient.Price.Denominator;
                                        DrawNumerator = ev.MainMarket.Selections.MatchResultDraw.Coefficient.Price.Numerator;
                                        tempDraw = (DrawDenominator + DrawNumerator) / DrawDenominator;
                                    }
                                    else
                                    {
                                        tempDraw = 0;
                                    }
                                    if (ev.MainMarket.Selections.MatchResult3 != null &&
                                        ev.MainMarket.Selections.MatchResult3.Coefficient != null &&
                                        ev.MainMarket.Selections.MatchResult3.Coefficient.Price != null &&
                                        ev.MainMarket.Selections.MatchResult3.Coefficient.Price.Denominator != 0 &&
                                        ev.MainMarket.Selections.MatchResult3.Coefficient.Price.Numerator != 0)
                                    {
                                        Win2Denominator = ev.MainMarket.Selections.MatchResult3.Coefficient.Price.Denominator;
                                        Win2Numerator = ev.MainMarket.Selections.MatchResult3.Coefficient.Price.Numerator;
                                        tempWin2 = (Win2Denominator + Win2Numerator) / Win2Denominator;
                                    }
                                    else
                                    {
                                        tempWin2 = 0;
                                    }
                                }
                                else
                                {
                                    tempWin1 = 0;
                                    tempDraw = 0;
                                    tempWin2 = 0;
                                }
                                tempMatch.coefficient = new Models.Coefficient { Win1 = tempWin1, Draw = tempDraw, Win2 = tempWin2 };
                                Matches.Add(tempMatch);
                            }
                        }
                    }
                }

            }

            return Matches;
        }
    }
}
