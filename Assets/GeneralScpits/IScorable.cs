public interface IScorable
{
    float score { get; set; }

    void Add(float score);

    void Remove(float score);
}