using Koko.Shared.Tracks;

namespace Koko.Server.Domain
{
    public class Track 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Description { get; set; }

        ///  need to add genre

        public TrackPrivacy Privacy { get; set; }

        public string CreatedById { get; set; }
        public AppUser CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastUpdatedOn { get; set; } = DateTime.Now;
    }
}
