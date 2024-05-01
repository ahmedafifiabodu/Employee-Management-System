namespace Task_10
{
    internal class SalesPerson : Employee
    {
        private readonly int EmployeeQuota;
        internal int AchievedTarget { get; } = 100;

        internal SalesPerson(int EmployeeID, DateTime BirthDate, int EmployeeQuota)
            : base(EmployeeID, BirthDate, 0)
        {
            this.EmployeeQuota = EmployeeQuota;
        }

        internal override void RequestVacation(DateTime From, DateTime To)
        {
            VacationStock = 0;

            Generic.MessageOperation(
               $"Your vacation has been accpeted. " +
               $"From: {From.Day}/{From.Month}/{From.Year}, " +
               $"To: {To.Day}/{To.Month}/{To.Year}", ConsoleColor.Green, true, true);
        }

        internal override void EndOfYearOperation()
        {
            age++;
        }

        public override string ToString()
        {
            return
                $"\t\tEmployee Type: {GetType().Name}, " +
                $"Employee ID: {EmployeeID}, " +
                $"Employee Age: {age}, " +
                $"Birth Date: {BirthDate.Day}/{BirthDate.Month}/{BirthDate.Year}, " +
                $"VacationStock: {VacationStock}, " +
                $"Current Quota: {EmployeeQuota}.";
        }

        #region Quota

        private static bool CheckTarget(int Quota)
        {
            if (Quota < 100)
                return false;
            return true;
        }

        internal Predicate<int> Quota { get; } = CheckTarget;

        internal void CheckEmployeeQuota(Predicate<int> Quota)
        {
            if (!Quota(EmployeeQuota))
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs
                {
                    Cause = LayOffCause.DidnotAchieveTargetQuota
                });
            }
        }

        #endregion Quota
    }
}