namespace Homework_5_Filatov_Vladyslav_Serhiyovych
{
    class SortByAmountOfExpenses : IComparer<Apartment>
    {
        public int Compare(Apartment? x, Apartment? y)
        {
            if (x is null || y is null)
                throw new ArgumentException("Null");
            return x.AmountOfExpenses.CompareTo(y.AmountOfExpenses);
        }
    }
}