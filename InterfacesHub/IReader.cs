namespace InterfacesHub
{
    public interface IReader
    {
        bool Read();
        (bool, string[]) ReadValueTuple();
    }
}