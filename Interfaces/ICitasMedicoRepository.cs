namespace CitasMedico.Repository
{
    public interface ICitasMedicoRepository<T> where T : class
    {
        bool Exist(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
