namespace DataAccess.Data.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        IEnumerable<Department> GetAll(bool withTracking = false);
        Department? GetById(int Id);
        int Remove(Department department);
        int Update(Department department);
    }
}