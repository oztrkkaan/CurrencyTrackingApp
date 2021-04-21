namespace Entities.Abstract
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
