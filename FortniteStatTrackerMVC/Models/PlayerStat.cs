using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FortniteStatTrackerMVC
{

    public partial class PlayerStat
    {
        public Guid AccountId { get; set; }
        public Uri Avatar { get; set; }
        public long PlatformId { get; set; }
        public string PlatformName { get; set; }
        public string PlatformNameLong { get; set; }
        public string EpicUserHandle { get; set; }
        [NotMapped]
        public Dictionary<string, Dictionary<string, Stat>> Stats { get; set; }
        public List<LifeTimeStat> LifeTimeStats { get; set; }
        public List<RecentMatch> RecentMatches { get; set; }
    }

    public partial class LifeTimeStat
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public partial class RecentMatch
    {
        public long Id { get; set; }
        public Guid AccountId { get; set; }
        public string Playlist { get; set; }
        public long Kills { get; set; }
        public long MinutesPlayed { get; set; }
        public long Top1 { get; set; }
        public long Top5 { get; set; }
        public long Top6 { get; set; }
        public long Top10 { get; set; }
        public long Top12 { get; set; }
        public long Top25 { get; set; }
        public long Matches { get; set; }
        public long Top3 { get; set; }
        public DateTimeOffset DateCollected { get; set; }
        public long Score { get; set; }
        public long Platform { get; set; }
        public double? TrnRating { get; set; }
        public double? TrnRatingChange { get; set; }
        public long PlaylistId { get; set; }
        public long PlayersOutlived { get; set; }
    }

    public partial class Stat
    {
        public string Label { get; set; }
        public string Field { get; set; }
        public string Category { get; set; }
        public double? ValueDec { get; set; }
        public string Value { get; set; }
        public string DisplayValue { get; set; }
        public long? ValueInt { get; set; }
        public long? Rank { get; set; }
        public double? Percentile { get; set; }
    }

    public enum Category { General, Rating, Tops };
}
