using System;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Marathonbet.Data
{ 
    public partial class RootObject
    {
        [JsonProperty("treeId")]
        public long TreeId { get; set; }

        [JsonProperty("parentTreeId")]
        public long ParentTreeId { get; set; }

        [JsonProperty("path")]
        public Path[] Path { get; set; }

        [JsonProperty("rawName")]
        public string RawName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("live")]
        public bool Live { get; set; }

        [JsonProperty("catInfo")]
        public RootObjectCatInfo CatInfo { get; set; }
    }

    public partial class RootObjectCatInfo
    {
        [JsonProperty("children")]
        public PurpleChild[] Children { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("link")]
        public bool Link { get; set; }
    }

    public partial class PurpleChild
    {
        [JsonProperty("treeId")]
        public long TreeId { get; set; }

        [JsonProperty("parentTreeId")]
        public long ParentTreeId { get; set; }

        [JsonProperty("rawName")]
        public string RawName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("live")]
        public bool Live { get; set; }

        [JsonProperty("eventInfo")]
        public EventInfo EventInfo { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }

        [JsonProperty("catInfo")]
        public ChildCatInfo CatInfo { get; set; }
    }

    public partial class ChildCatInfo
    {
        [JsonProperty("children")]
        public FluffyChild[] Children { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("link")]
        public bool Link { get; set; }
    }

    public partial class FluffyChild
    {
        [JsonProperty("treeId")]
        public long TreeId { get; set; }

        [JsonProperty("parentTreeId")]
        public long ParentTreeId { get; set; }

        [JsonProperty("rawName")]
        public string RawName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("live")]
        public bool Live { get; set; }

        [JsonProperty("eventInfo")]
        public EventInfo EventInfo { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }

        [JsonProperty("catInfo")]
        public FluffyCatInfo CatInfo { get; set; }
    }

    public partial class Event
    {
        [JsonProperty("american")]
        public bool American { get; set; }

        [JsonProperty("catTreeId")]
        public long CatTreeId { get; set; }

        [JsonProperty("mainMarket")]
        public MainMarket MainMarket { get; set; }

        [JsonProperty("marketsCount")]
        public long MarketsCount { get; set; }

        [JsonProperty("treeId")]
        public long TreeId { get; set; }

        [JsonProperty("eventId")]
        public long EventId { get; set; }

        [JsonProperty("displayTime")]
        public long DisplayTime { get; set; }

        [JsonProperty("matchTimeInfo")]
        public MatchTimeInfo MatchTimeInfo { get; set; }

        [JsonProperty("homeTeam")]
        public Team HomeTeam { get; set; }

        [JsonProperty("awayTeam")]
        public Team AwayTeam { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }
    }

    public partial class Team
    {
        [JsonProperty("members")]
        public Member[] Members { get; set; }
    }

    public partial class Member
    {
        [JsonProperty("memberCode")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long MemberCode { get; set; }

        [JsonProperty("memberName")]
        public string MemberName { get; set; }

        [JsonProperty("memberId")]
        public long MemberId { get; set; }

        [JsonProperty("competitor")]
        public string Competitor { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public partial class MainMarket
    {
        [JsonProperty("selections")]
        public Selections Selections { get; set; }

        [JsonProperty("homeDrawAwayHandicapInfo")]
        public HomeDrawAwayHandicapInfo HomeDrawAwayHandicapInfo { get; set; }

        [JsonProperty("marketModel")]
        public string MarketModel { get; set; }

        [JsonProperty("marketType")]
        public string MarketType { get; set; }

        [JsonProperty("marketState")]
        public string MarketState { get; set; }

        [JsonProperty("marketCode")]
        public string MarketCode { get; set; }

        [JsonProperty("marketId")]
        public long MarketId { get; set; }

        [JsonProperty("marketName")]
        public string MarketName { get; set; }
    }

    public partial class HomeDrawAwayHandicapInfo
    {
        [JsonProperty("awaySelectionUid")]
        public string AwaySelectionUid { get; set; }

        [JsonProperty("homeSelectionUid")]
        public string HomeSelectionUid { get; set; }

        [JsonProperty("drawSelectionUid")]
        public string DrawSelectionUid { get; set; }
    }

    public partial class Selections
    {
        [JsonProperty("Match_Result.3")]
        public MatchResult MatchResult3 { get; set; }

        [JsonProperty("Match_Result.1")]
        public MatchResult MatchResult1 { get; set; }

        [JsonProperty("Match_Result.draw")]
        public MatchResult MatchResultDraw { get; set; }
    }

    public partial class MatchResult
    {
        [JsonProperty("selId")]
        public long SelId { get; set; }

        [JsonProperty("selUid")]
        public string SelUid { get; set; }

        [JsonProperty("selName")]
        public string SelName { get; set; }

        [JsonProperty("selState")]
        public string SelState { get; set; }

        [JsonProperty("displayed")]
        public bool Displayed { get; set; }

        [JsonProperty("memberCode", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? MemberCode { get; set; }

        [JsonProperty("dangerous")]
        public bool Dangerous { get; set; }

        [JsonProperty("coefficient")]
        public Coefficient Coefficient { get; set; }
    }

    public partial class Coefficient
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Price
    {
        [JsonProperty("denominator")]
        public long Denominator { get; set; }

        [JsonProperty("numerator")]
        public long Numerator { get; set; }
    }

    public partial class MatchTimeInfo
    {
        [JsonProperty("secondsFromStart")]
        public long SecondsFromStart { get; set; }

        [JsonProperty("isBreak")]
        public bool IsBreak { get; set; }

        [JsonProperty("extraTime")]
        public bool ExtraTime { get; set; }

        [JsonProperty("timeString")]
        public string TimeString { get; set; }

        [JsonProperty("breakType", NullValueHandling = NullValueHandling.Ignore)]
        public string BreakType { get; set; }
    }

    public enum Competitor { Away, Home };

    public enum Role { Team };

    public enum Uid { MatchResult1, MatchResult3, MatchResultDraw };

    public enum TypeEnum { Cp };

    public enum SelState { Active };

    public partial class EventInfo
    {
        [JsonProperty("eventId")]
        public long EventId { get; set; }

        [JsonProperty("eventStatus")]
        public string EventStatus { get; set; }

        [JsonProperty("emulateCategoryForMenu")]
        public bool EmulateCategoryForMenu { get; set; }

        [JsonProperty("displayTime")]
        public long DisplayTime { get; set; }
    }

    public partial class Path
    {
        [JsonProperty("treeId")]
        public long TreeId { get; set; }

        [JsonProperty("parentTreeId")]
        public long ParentTreeId { get; set; }

        [JsonProperty("rawName")]
        public string RawName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("live")]
        public bool Live { get; set; }

        [JsonProperty("catInfo")]
        public PathCatInfo CatInfo { get; set; }
    }

    public partial class PathCatInfo
    {
        [JsonProperty("children")]
        public FluffyChild[] Children { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("link")]
        public bool Link { get; set; }
    }

    public partial class CatInfo
    {
        [JsonProperty("children")]
        public FluffyChild[] Children { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("link")]
        public bool Link { get; set; }
    }
    
    public partial class PurpleCatInfo
    {
        [JsonProperty("children")]
        public FluffyChild[] Children { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("link")]
        public bool Link { get; set; }
    }

    public partial class FluffyCatInfo
    {
        [JsonProperty("children")]
        public FluffyChild[] FluffyChilds { get; set; }
        
        [JsonProperty("children")]
        public TentacledChild[] TentacledChilds { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("link")]
        public bool Link { get; set; }
    }

    public partial class TentacledChild
    {
        [JsonProperty("treeId")]
        public long TreeId { get; set; }

        [JsonProperty("parentTreeId")]
        public long ParentTreeId { get; set; }

        [JsonProperty("rawName")]
        public string RawName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("live")]
        public bool Live { get; set; }

        [JsonProperty("catInfo")]
        public TentacledCatInfo CatInfo { get; set; }

        [JsonProperty("eventInfo")]
        public EventInfo EventInfo { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }
    }
    public partial class TentacledCatInfo
    {
        [JsonProperty("children")]
        public StickyChild[] Children { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("link")]
        public bool Link { get; set; }
    }
    public partial class StickyChild
    {
        [JsonProperty("treeId")]
        public long TreeId { get; set; }

        [JsonProperty("parentTreeId")]
        public long ParentTreeId { get; set; }

        [JsonProperty("rawName")]
        public string RawName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("live")]
        public bool Live { get; set; }

        [JsonProperty("catInfo")]
        public StickyCatInfo CatInfo { get; set; }

        [JsonProperty("eventInfo")]
        public EventInfo EventInfo { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }
    }
    public partial class StickyCatInfo
    {
        [JsonProperty("children")]
        public IndigoChild[] Children { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("link")]
        public bool Link { get; set; }
    }
    public partial class IndigoChild
    {
        [JsonProperty("treeId")]
        public long TreeId { get; set; }

        [JsonProperty("parentTreeId")]
        public long ParentTreeId { get; set; }

        [JsonProperty("rawName")]
        public string RawName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("live")]
        public bool Live { get; set; }

        [JsonProperty("eventInfo")]
        public EventInfo EventInfo { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }

        [JsonProperty("catInfo")]
        public StickyCatInfo CatInfo { get; set; }
    }

    public partial class RootObject
    {
        public static RootObject FromJson(string json) => JsonConvert.DeserializeObject<RootObject>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RootObject self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CompetitorConverter.Singleton,
                RoleConverter.Singleton,
                UidConverter.Singleton,
                TypeEnumConverter.Singleton,
                SelStateConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class CompetitorConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Competitor) || t == typeof(Competitor?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AWAY":
                    return Competitor.Away;
                case "HOME":
                    return Competitor.Home;
            }
            throw new Exception("Cannot unmarshal type Competitor");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Competitor)untypedValue;
            switch (value)
            {
                case Competitor.Away:
                    serializer.Serialize(writer, "AWAY");
                    return;
                case Competitor.Home:
                    serializer.Serialize(writer, "HOME");
                    return;
            }
            throw new Exception("Cannot marshal type Competitor");
        }

        public static readonly CompetitorConverter Singleton = new CompetitorConverter();
    }

    internal class RoleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Role) || t == typeof(Role?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Team")
            {
                return Role.Team;
            }
            throw new Exception("Cannot unmarshal type Role");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Role)untypedValue;
            if (value == Role.Team)
            {
                serializer.Serialize(writer, "Team");
                return;
            }
            throw new Exception("Cannot marshal type Role");
        }

        public static readonly RoleConverter Singleton = new RoleConverter();
    }

    internal class UidConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Uid) || t == typeof(Uid?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Match_Result.1":
                    return Uid.MatchResult1;
                case "Match_Result.3":
                    return Uid.MatchResult3;
                case "Match_Result.draw":
                    return Uid.MatchResultDraw;
            }
            throw new Exception("Cannot unmarshal type Uid");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Uid)untypedValue;
            switch (value)
            {
                case Uid.MatchResult1:
                    serializer.Serialize(writer, "Match_Result.1");
                    return;
                case Uid.MatchResult3:
                    serializer.Serialize(writer, "Match_Result.3");
                    return;
                case Uid.MatchResultDraw:
                    serializer.Serialize(writer, "Match_Result.draw");
                    return;
            }
            throw new Exception("Cannot marshal type Uid");
        }

        public static readonly UidConverter Singleton = new UidConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "CP")
            {
                return TypeEnum.Cp;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            if (value == TypeEnum.Cp)
            {
                serializer.Serialize(writer, "CP");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class SelStateConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SelState) || t == typeof(SelState?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Active")
            {
                return SelState.Active;
            }
            throw new Exception("Cannot unmarshal type SelState");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SelState)untypedValue;
            if (value == SelState.Active)
            {
                serializer.Serialize(writer, "Active");
                return;
            }
            throw new Exception("Cannot marshal type SelState");
        }

        public static readonly SelStateConverter Singleton = new SelStateConverter();
    }
}
