namespace Epila.Ph.WebApi.Data.Entity
{
    public class KioskQueueType : EntityBase
    {
        public int  Id { get; set; }
        public int KioskId { get; set; }
        public int QueueTypeId { get; set; }
        public bool IsActive { get; set; }
        public string ReferenceLink { get; set; }
    }
}
