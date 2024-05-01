namespace Task_10
{
    internal class Club
    {
        internal int ClubID { get; set; }
        internal string ClubName { get; set; }

        private readonly List<Employee> ClubMembers;

        internal List<Employee> ClubMembersList
        {
            get { return ClubMembers; }
        }

        public Club(int ID, string Name)
        {
            ClubID = ID;
            ClubName = Name;
            ClubMembers = new();
        }

        public void AddMember(Employee E)
        {
            ClubMembers.Add(E);
            if (E is BoardMember boardMember)
            {
                Console.WriteLine($"Board Member {boardMember.EmployeeID} added to Club {ClubID} - {ClubName} (Forever Member)");
            }
            else
            {
                Console.WriteLine($"Employee {E.EmployeeID} added to Club {ClubID} - {ClubName}");

                // Try registering for EmployeeLayOff event here
                E.EmployeeLayOff += RemoveMember!;
            }
        }

        internal void DisplayStaff()
        {
            if (ClubMembersList.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (Employee employee in ClubMembers)
                {
                    Console.WriteLine(employee.ToString());
                }
                Console.ResetColor();
            }
            else
            {
                Generic.SetInCenter("There is no employee to display.");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no employee to display.");
                Console.ResetColor();
            }
        }

        ///CallBackMethod
        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            ///Employee Will not be removed from the Club if Age > 60
            ///Employee will be removed from Club if Vacation Stock < 0
            ///

            if (sender is Employee employee)
            {
                if (employee.EmployeeAge > 60)
                {
                    Generic.MessageOperation(
                        $"Employee {employee.EmployeeID} is over 60, and remains in {ClubName} Club.",
                        ConsoleColor.Blue, true, true);
                }

                if (employee.VacationStock <= 0)
                {
                    ClubMembers.Remove(employee);

                    Generic.MessageOperation(
                        $"Employee {employee.EmployeeID} has been removed from {ClubName} Club. Cause: {e.Cause}",
                        ConsoleColor.DarkRed, true, true);
                }
            }
        }
    }
}