public interface IInterractable
{
    public void Interract();
    public Effect GetEffect();
}

public enum Effect
{
    GetBurger,
    GiveBurger,
    GetMoney
}