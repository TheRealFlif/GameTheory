namespace GameTheory.Logic.Entities;

internal interface IStrategy
{
    public  Choice Next(Choice opponentPreviousChoice);
}
