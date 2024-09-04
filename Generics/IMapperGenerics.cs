namespace NetCrud2.Generics
{
    public interface IMapperGenerics<E, C, U, R>
    {
        R EntityToResponse(E entity);
        E CreateToEntity(C create);
        E UpdatetoEntity(U update, E entity);
        List<R> ListEntitytoResponse(List<E> entities);
    }
}
