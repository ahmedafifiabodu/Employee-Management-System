namespace Task_10
{
    internal class BoardMember : Employee
    {
        internal BoardMember(int EmployeeID, DateTime BirthDate)
            : base(EmployeeID, BirthDate, 0)
        {
        }

        internal override void RequestVacation(DateTime From, DateTime To)
        {
            Generic.MessageOperation(
                "Your vacation has been automatically disapproved. " +
                "Please contact your administrator for futher assistance."
                , ConsoleColor.DarkRed, true, true);
        }

        internal override void EndOfYearOperation()
        {
            age++;
        }

        internal void Resign()
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs
            {
                Cause = LayOffCause.Resignation
            });
        }

        public override string ToString()
        {
            return
                $"\t\tEmployee Type: {GetType().Name}, " +
                $"Employee ID: {EmployeeID}, " +
                $"Employee Age: {age}, " +
                $"Birth Date: {BirthDate.Day}/{BirthDate.Month}/{BirthDate.Year}.";
        }
    }
}