namespace Task_10
{
    internal class Employee
    {
        internal event EventHandler<EmployeeLayOffEventArgs>? EmployeeLayOff;

        private int ID;
        private int vacationStock;
        private DateTime birthDate;
        private readonly DateTime CheckBirthDate;
        private protected int age;

        internal Employee(int EmployeeID, DateTime BirthDate, int VacationStock)
        {
            this.EmployeeID = EmployeeID;
            CheckBirthDate = BirthDate;
            this.BirthDate = BirthDate;
            this.VacationStock = VacationStock;
        }

        internal int EmployeeID
        {
            get { return ID; }
            set { ID = value; }
        }

        internal int EmployeeAge
        { get { return age; } }

        internal DateTime BirthDate
        {
            get { return birthDate; }

            set
            {
                DateTime today = DateTime.Today;
                age = today.Year - CheckBirthDate.Year;

                if (age >= 60)
                {
                    Generic.MessageOperation(
                        "The employee is order than 60! " +
                        "Automatically disqualify.", ConsoleColor.Red, true, true);
                }
                else { birthDate = value; }
            }
        }

        internal int VacationStock
        {
            get { return vacationStock; }
            set { vacationStock = value; }
        }

        internal virtual void RequestVacation(DateTime From, DateTime To)
        {
            if (VacationStock > 0)
            {
                VacationStock--;

                Generic.MessageOperation(
                    $"Your vacation has been accpeted. " +
                    $"From: {From.Day}/{From.Month}/{From.Year}, " +
                    $"To: {To.Day}/{To.Month}/{To.Year}", ConsoleColor.Green, true, true);
            }
            else if (VacationStock <= 0)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs
                {
                    Cause = LayOffCause.VacationStockNegative
                });
            }
        }

        internal virtual void EndOfYearOperation()
        {
            age++;

            if (age >= 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.AgeExceeds60 });
            }
        }

        public override string ToString()
        {
            return
                $"\t\tEmployee Type: {GetType().Name}, " +
                $"Employee ID: {EmployeeID}, " +
                $"Employee Age: {age}, " +
                $"Birth Date: {BirthDate.Day}/{BirthDate.Month}/{BirthDate.Year}, " +
                $"VacationStock: {VacationStock}.";
        }

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }
    }
}