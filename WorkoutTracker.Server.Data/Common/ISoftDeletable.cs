namespace WorkoutTracker.Server.Data.Common
{
    internal interface ISoftDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedDate { get; set; }
    }
}
