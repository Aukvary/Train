public interface IScorable<T>
{
    T Score { get; set; }

    void AddScore(T score);

    void RemoveScore(T score);
}