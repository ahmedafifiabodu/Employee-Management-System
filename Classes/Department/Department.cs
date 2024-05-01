namespace Task_10
{
    internal class Department
    {
        internal int DeptID { get; set; }
        internal string DeptName { get; set; }

        private readonly List<Employee> Staff;

        public List<Employee> Staffs
        {
            get { return Staff; }
        }

        public Department(int ID, string Name)
        {
            DeptID = ID;
            DeptName = Name;
            Staff = new();
        }

        internal void AddStaff(Employee E)
        {
            Staff.Add(E);
            E.EmployeeLayOff += RemoveStaff!;
            ///Try Register for EmployeeLayOff Event Here
        }

        internal void DisplayStaff()
        {
            if (Staff.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (Employee employee in Staff)
                {
                    Console.WriteLine(employee.ToString());
                }
                Console.ResetColor();
            }
            else
            {
                Generic.SetInCenter("There is no employee to display.");
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tThere is no employee to display.");
                Console.ResetColor();
            }
        }

        ///CallBackMethod
        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee employee)
            {
                Staff.Remove(employee);
                Generic.MessageOperation(
                    $"Employee {employee.EmployeeID} has been removed from {DeptName} department. Cause: {e.Cause}",
                    ConsoleColor.DarkRed, true, true);
            }
        }
    }
}