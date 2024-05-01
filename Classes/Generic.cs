namespace Task_10
{
    internal class Generic
    {
        internal static List<Department> departments = new();
        internal static List<Club> clubs = new();

        #region Common Functions

        private static int FindIndex<T>(int id, List<T> items, Func<T, int> getId)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (getId(items[i]) == id)
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool IsExists<T>(int id, List<T> entities, Func<T, int> getId)
        {
            return entities.Any(item => getId(item) == id);
        }

        private static Func<T, int> GetIDFunction<T>()
        {
            if (typeof(T) == typeof(Department))
            {
                return (Func<T, int>)(object)((Department d) => d.DeptID);
            }
            else if (typeof(T) == typeof(Club))
            {
                return (Func<T, int>)(object)((Club c) => c.ClubID);
            }
            else if (typeof(T) == typeof(Employee))
            {
                return (Func<T, int>)(object)((Employee e) => e.EmployeeID);
            }
            else
            {
                throw new InvalidOperationException("Unsupported type");
            }
        }

        #endregion Common Functions

        #region Add Department/Club

        internal static void AddEntity<T>(List<T> entities, string entityTypeName)
        {
            Console.Write($"Enter {entityTypeName} ID: ");
            int entityID;

            while (!int.TryParse(Console.ReadLine(), out entityID) || entityID <= 0
                || IsExists(entityID, entities, GetIDFunction<T>()))
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);
                Console.Write($"Enter {entityTypeName} ID: ");
            }

            Console.Clear();
            Console.Write($"Enter {entityTypeName} Name: ");
            string entityName = "";

            while (string.IsNullOrEmpty(entityName) || string.IsNullOrWhiteSpace(entityName))
            {
                entityName = Console.ReadLine()!;

                if (string.IsNullOrEmpty(entityName) || string.IsNullOrWhiteSpace(entityName))
                {
                    MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);
                    Console.Write($"Enter {entityTypeName} Name: ");
                }
            }

            //List.Add(new(entityID, DepartmentName));

            entities.Add((T)Activator.CreateInstance(typeof(T), entityID, entityName)!);
            MessageOperation($"The {entityName} {entityTypeName.ToLower()} has been added successfully", ConsoleColor.Green, true, true);
        }

        #endregion Add Department/Club

        #region Add Employee

        #region Employees Helper FUnctions

        private static bool IsExists<T>(int employeeID, T entity, Func<T, List<Employee>> getStaffsFunction)
        {
            List<Employee> staffs = getStaffsFunction(entity);
            return staffs.Any(item => item.EmployeeID == employeeID);
        }

        private static Func<T, List<Employee>> GetStaffsFunction<T>()
        {
            if (typeof(T) == typeof(Department))
            {
                return (Func<T, List<Employee>>)(object)((Department d) => d.Staffs);
            }
            else if (typeof(T) == typeof(Club))
            {
                return (Func<T, List<Employee>>)(object)((Club c) => c.ClubMembersList);
            }
            else
            {
                throw new InvalidOperationException("Unsupported type");
            }
        }

        private static Func<T, string> GetDisplayFunction<T>()
        {
            if (typeof(T) == typeof(Department))
            {
                return (Func<T, string>)(object)((Department d) =>
                    $"\t{nameof(Department)} ID: {d.DeptID}, Department Name: {d.DeptName}");
            }
            else if (typeof(T) == typeof(Club))
            {
                return (Func<T, string>)(object)((Club c) =>
                    $"\t{nameof(Club)} ID: {c.ClubID}, Club Name: {c.ClubName}");
            }
            else
            {
                throw new InvalidOperationException("Unsupported type");
            }
        }

        #endregion Employees Helper FUnctions

        #region Add Employee

        internal static void AddEmployee<T>(List<T> entities, string entityTypeName, int EmployeeType)
        {
            if (entities.Count == 0)
            {
                MessageOperation($"The is no {entityTypeName.ToLower()} added yet.", ConsoleColor.Red, true, true);
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Display(entities, $"{nameof(T)}", false);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write($"\n\n\tEnter the {entityTypeName} ID: ");
            int entityID;
            while (!int.TryParse(Console.ReadLine(), out entityID)
                || !IsExists(entityID, entities, GetIDFunction<T>()))
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Display(entities, $"{nameof(T)}", false);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write($"\n\n\tEnter the {entityTypeName} ID: ");
            }

            Console.Write("\tEnter the Employee ID: ");
            int employeeID;
            int x = FindIndex(entityID, entities, GetIDFunction<T>());

            while (!int.TryParse(Console.ReadLine(), out employeeID) || employeeID <= 0 ||
                    IsExists(employeeID, entities[x], GetStaffsFunction<T>()))
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Display(entities, $"{nameof(T)}", false);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n\tEnter the Employee ID: ");
            }

            Console.WriteLine("\n\tEnter the date: ");

            Console.Write("\t\tDay: ");
            int day;
            while (!int.TryParse(Console.ReadLine(), out day) || day > 31 || day <= 0)
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Display(entities, $"{nameof(T)}", false);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n\t\tDay: ");
            }

            Console.Write("\t\tMonth: ");
            int month;
            while (!int.TryParse(Console.ReadLine(), out month) || month > 12 || month <= 0)
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Display(entities, $"{nameof(T)}", false);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n\t\tMonth: ");
            }

            Console.Write("\t\tYear: ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year) || year > 2005 || year < 1900)
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Display(entities, $"{nameof(T)}", false);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n\t\tYear: ");
            }

            if (EmployeeType == 0)
            {
                if (entities is List<Department> departments)
                {
                    departments[FindIndex(entityID, departments, GetIDFunction<Department>())].AddStaff(new Employee(employeeID, new DateTime(year, month, day), new Random().Next(1, 3)));
                }
                else if (entities is List<Club> clubs)
                {
                    clubs[FindIndex(entityID, clubs, GetIDFunction<Club>())].AddMember(new Employee(employeeID, new DateTime(year, month, day), new Random().Next(1, 3)));
                }
            }
            else if (EmployeeType == 1)
            {
                if (entities is List<Department> departments)
                {
                    departments[FindIndex(entityID, departments, GetIDFunction<Department>())].AddStaff(new SalesPerson(employeeID, new DateTime(year, month, day), new Random().Next(1, 100)));
                }
                else if (entities is List<Club> clubs)
                {
                    clubs[FindIndex(entityID, clubs, GetIDFunction<Club>())].AddMember(new SalesPerson(employeeID, new DateTime(year, month, day), new Random().Next(1, 100)));
                }
            }
            else if (EmployeeType == 2)
            {
                if (entities is List<Department> departments)
                {
                    departments[FindIndex(entityID, departments, GetIDFunction<Department>())].AddStaff(new BoardMember(employeeID, new DateTime(year, month, day)));
                }
                else if (entities is List<Club> clubs)
                {
                    clubs[FindIndex(entityID, clubs, GetIDFunction<Club>())].AddMember(new BoardMember(employeeID, new DateTime(year, month, day)));
                }
            }

            Console.Clear();
        }

        #endregion Add Employee

        #endregion Add Employee

        #region Display

        internal static void SetInCenter(string input)
        {
            Console.SetCursorPosition((Console.WindowWidth - input.Length) / 2, Console.CursorTop);
        }

        internal static void MessageOperation(string invalid, ConsoleColor color, bool readKey, bool center)
        {
            if (readKey) Console.Clear();

            Console.ForegroundColor = color;

            if (center) SetInCenter(invalid);

            Console.WriteLine(invalid + "\n");

            if (readKey)
            {
                Console.ReadKey();
                Console.Clear();
            }

            Console.ResetColor();
        }

        internal static void Display<T>(List<T> entities, string format, bool ShowEmployee)
        {
            if (entities.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{typeof(T).Name} List: ");

                foreach (T entity in entities)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (entity is Department d)
                    {
                        Console.WriteLine($"\t{nameof(Department)} ID: {d.DeptID}, Department Name: {d.DeptName}");
                    }
                    else if (entity is Club c)
                    {
                        Console.WriteLine($"\t{nameof(Club)} ID: {c.ClubID}, Club Name: {c.ClubName}");
                    }

                    if (ShowEmployee)
                    {
                        if (entity is Department department)
                        {
                            department.DisplayStaff();
                        }
                        else if (entity is Club club)
                        {
                            club.DisplayStaff();
                        }
                    }
                }
                Console.ResetColor();
            }
        }

        #endregion Display

        #region Check Emoployee Quota

        internal static void CheckQuota()
        {
            Display(departments, "Department", true);
            Display(clubs, "Club", true);

            if (departments.Count == 0)
            {
                MessageOperation("There are no departments been added yet.", ConsoleColor.Red, true, true);
            }
            else
            {
                foreach (Department entity in departments)
                {
                    int DepartmentIndex = FindIndex(entity.DeptID, departments, GetIDFunction<Department>());

                    if (entity.Staffs.Count == 0)
                    {
                        MessageOperation($"The department {entity.DeptName} does not have any empolyee.", ConsoleColor.Red, true, true);
                    }
                    else
                    {
                        foreach (Employee employee in new List<Employee>(departments[DepartmentIndex].Staffs))
                        {
                            if (employee is SalesPerson)
                            {
                                SalesPerson? emp = employee as SalesPerson;
                                emp?.CheckEmployeeQuota(emp.Quota);
                            }
                        }

                        MessageOperation($"Checking Quota operation have been completed successfully in all the departments.", ConsoleColor.DarkMagenta, true, true);
                    }
                }
            }

            if (clubs.Count == 0)
            {
                MessageOperation("There are no clubs been added yet.", ConsoleColor.Red, true, true);
            }
            else
            {
                foreach (Club entity in clubs)
                {
                    int DepartmentIndex = FindIndex(entity.ClubID, clubs, GetIDFunction<Club>());

                    if (entity.ClubMembersList.Count == 0)
                    {
                        MessageOperation($"The club {entity.ClubName} does not have any empolyee.", ConsoleColor.Red, true, true);
                    }
                    else
                    {
                        foreach (Employee employee in new List<Employee>(clubs[DepartmentIndex].ClubMembersList))
                        {
                            if (employee is SalesPerson)
                            {
                                SalesPerson? emp = employee as SalesPerson;
                                emp?.CheckEmployeeQuota(emp.Quota);
                            }
                        }

                        MessageOperation($"Checking Quota operation have been completed successfully in all the clubs.", ConsoleColor.DarkMagenta, true, true);
                    }
                }
            }
        }

        #endregion Check Emoployee Quota

        #region Request Resign

        internal static void RequestResign<T>(List<T> entities, string entityTypeName)
        {
            if (entities.Count == 0)
            {
                MessageOperation($"There is no {entityTypeName} been added yet.", ConsoleColor.Red, true, true);
                return;
            }

            Display(Generic.departments, "Department", true);
            Display(clubs, "Club", true);

            Console.Write($"\n\n\tEnter {entityTypeName} ID: ");
            int entityID;
            while (!int.TryParse(Console.ReadLine(), out entityID)
                || !IsExists(entityID, entities, GetIDFunction<T>()))
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Display(entities, $"{nameof(T)}", true);
                Console.ResetColor();

                Console.Write($"\n\n\tEnter the {entityTypeName} ID: ");
            }

            if (entities is List<Department> department)
            {
                int DepartmentIndex = FindIndex(entityID, department, GetIDFunction<Department>());
                if (department[DepartmentIndex].Staffs.Count == 0)
                {
                    MessageOperation($"There is no employee in Department Name: {department[DepartmentIndex].DeptName}", ConsoleColor.Red, true, true);
                    return;
                }
            }
            else if (entities is List<Club> club)
            {
                int ClubIndex = FindIndex(entityID, club, GetIDFunction<Club>());
                if (club[ClubIndex].ClubMembersList.Count == 0)
                {
                    MessageOperation($"There is no employee in Department Name: {club[ClubIndex].ClubName}", ConsoleColor.Red, true, true);
                    return;
                }
            }

            Console.Write("\tEnter the Employee ID: ");
            int employeeID;
            int x = FindIndex(entityID, entities, GetIDFunction<T>());

            while (!int.TryParse(Console.ReadLine(), out employeeID) ||
                    !IsExists(employeeID, entities[x], GetStaffsFunction<T>()))
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);
                Display(entities, $"{nameof(T)}", true);
                Console.Write("\n\tEnter the Employee ID: ");
            }

            if (entities is List<Department> departments)
            {
                int DepartmentIndex = FindIndex(entityID, departments, GetIDFunction<Department>());
                int EmployeeIndex = FindIndex(employeeID, departments[DepartmentIndex].Staffs, GetIDFunction<Employee>());

                if (departments[DepartmentIndex].Staffs[EmployeeIndex] is BoardMember)
                {
                    if (departments[DepartmentIndex].Staffs.Count == 0)
                    {
                        MessageOperation($"The department {departments[DepartmentIndex].DeptName} does not have any empolyee.", ConsoleColor.Red, true, true);
                    }
                    else
                    {
                        foreach (Employee employee in new List<Employee>(departments[DepartmentIndex].Staffs))
                        {
                            if (employee is BoardMember)
                            {
                                BoardMember? boardMember = employee as BoardMember;
                                boardMember?.Resign();
                            }
                        }
                    }
                    MessageOperation("Resigning operation have been completed successfully.", ConsoleColor.DarkMagenta, true, true);
                }
                else
                {
                    MessageOperation($"Employee ID {employeeID} is not a Board Employee.", ConsoleColor.Red, true, true);
                }
            }
            else if (entities is List<Club> clubs)
            {
                int ClubIndex = FindIndex(entityID, clubs, GetIDFunction<Club>());
                int EmployeeIndex = FindIndex(employeeID, clubs[ClubIndex].ClubMembersList, GetIDFunction<Employee>());

                if (clubs[ClubIndex].ClubMembersList[EmployeeIndex] is BoardMember)
                {
                    if (clubs[ClubIndex].ClubMembersList.Count == 0)
                    {
                        MessageOperation($"The club {clubs[ClubIndex].ClubName} does not have any empolyee.", ConsoleColor.Red, true, true);
                    }
                    else
                    {
                        foreach (Employee employee in new List<Employee>(clubs[ClubIndex].ClubMembersList))
                        {
                            if (employee is BoardMember)
                            {
                                //The BoardMember will not be removed even if i call the resign function.
                                //BoardMember? boardMember = employee as BoardMember;
                                //boardMember?.Resign();

                                MessageOperation($"Board Member will be forever a member of this Club {clubs[ClubIndex].ClubName}", ConsoleColor.DarkMagenta, true, true);
                            }
                        }
                    }
                    MessageOperation($"Resigning operation have been completed successfully.", ConsoleColor.DarkMagenta, true, true);
                }
                else
                {
                    MessageOperation($"Employee ID {employeeID} is not a Board Employee.", ConsoleColor.Red, true, true);
                }
            }
        }

        #endregion Request Resign

        #region Request Vacation

        internal static void RequestVacation<T>(List<T> entities, string entityTypeName)
        {
            if (entities.Count == 0)
            {
                MessageOperation($"There is no {entityTypeName} been added yet.", ConsoleColor.Red, true, true);
                return;
            }

            Display(entities, $"{entityTypeName}", true);

            Console.Write($"\n\n\tEnter {entityTypeName} ID: ");
            int entityID;
            while (!int.TryParse(Console.ReadLine(), out entityID)
                || !IsExists(entityID, entities, GetIDFunction<T>()))
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Display(entities, $"{nameof(T)}", true);
                Console.ResetColor();

                Console.Write($"\n\n\tEnter the {entityTypeName} ID: ");
            }

            if (entities is List<Department> department)
            {
                int DepartmentIndex = FindIndex(entityID, department, GetIDFunction<Department>());
                if (department[DepartmentIndex].Staffs.Count == 0)
                {
                    MessageOperation($"There is no employee in Department Name: {department[DepartmentIndex].DeptName}", ConsoleColor.Red, true, true);
                    return;
                }
            }
            else if (entities is List<Club> club)
            {
                int ClubIndex = FindIndex(entityID, club, GetIDFunction<Club>());
                if (club[ClubIndex].ClubMembersList.Count == 0)
                {
                    MessageOperation($"There is no employee in Department Name: {club[ClubIndex].ClubName}", ConsoleColor.Red, true, true);
                    return;
                }
            }

            Console.Write("\tEnter the Employee ID: ");
            int employeeID;
            int x = FindIndex(entityID, entities, GetIDFunction<T>());

            while (!int.TryParse(Console.ReadLine(), out employeeID) ||
                    !IsExists(employeeID, entities[x], GetStaffsFunction<T>()))
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);
                Display(entities, $"{nameof(T)}", true);
                Console.Write("\n\tEnter the Employee ID: ");
            }

            Console.WriteLine("\n\tVacatoin Start date: ");

            Console.Write("\t\tDay: ");
            int VacatoinStartDay;
            while (!int.TryParse(Console.ReadLine(), out VacatoinStartDay) || VacatoinStartDay > 31 || VacatoinStartDay <= 0)
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Display(entities, $"{nameof(T)}", true);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n\t\tDay: ");
            }

            Console.Write("\t\tMonth: ");
            int VacatoinStartMonth;
            while (!int.TryParse(Console.ReadLine(), out VacatoinStartMonth) || VacatoinStartMonth > 12 || VacatoinStartMonth <= 0)
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Display(entities, $"{nameof(T)}", true);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n\t\tMonth: ");
            }

            Console.Write("\t\tYear: ");
            int VacatoinStartYear;
            while (!int.TryParse(Console.ReadLine(), out VacatoinStartYear) || VacatoinStartYear > 2005 || VacatoinStartYear < 1900)
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Display(entities, $"{nameof(T)}", true);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n\t\tYear: ");
            }

            Console.WriteLine("\n\tVacatoin End date: ");

            Console.Write("\t\tDay: ");
            int VacatoinEndDay;
            while (!int.TryParse(Console.ReadLine(), out VacatoinEndDay) || VacatoinEndDay > 31 || VacatoinEndDay <= 0)
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Display(entities, $"{nameof(T)}", false);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n\t\tDay: ");
            }

            Console.Write("\t\tMonth: ");
            int VacatoinEndMonth;
            while (!int.TryParse(Console.ReadLine(), out VacatoinEndMonth) || VacatoinEndMonth > 12 || VacatoinEndMonth <= 0)
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Display(entities, $"{nameof(T)}", false);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n\t\tMonth: ");
            }

            Console.Write("\t\tYear: ");
            int VacatoinEndYear;
            while (!int.TryParse(Console.ReadLine(), out VacatoinEndYear) || VacatoinEndYear > 2005 || VacatoinEndYear < 1900)
            {
                MessageOperation("Invalid Input! Please try again.", ConsoleColor.Red, true, true);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Display(entities, $"{nameof(T)}", false);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n\t\tYear: ");
            }

            DateTime StartVacation = new(VacatoinStartYear, VacatoinStartMonth, VacatoinStartDay);
            DateTime EndVacation = new(VacatoinEndYear, VacatoinEndMonth, VacatoinEndDay);

            if (entities is List<Department> departments)
            {
                int DepartmentIndex = FindIndex(entityID, departments, GetIDFunction<Department>());
                int EmployeeIndex = FindIndex(employeeID, departments[DepartmentIndex].Staffs, GetIDFunction<Employee>());
                departments[DepartmentIndex].Staffs[EmployeeIndex].RequestVacation(StartVacation, EndVacation);
            }
            else if (entities is List<Club> clubs)
            {
                int ClubIndex = FindIndex(entityID, clubs, GetIDFunction<Club>());
                int EmployeeIndex = FindIndex(employeeID, clubs[ClubIndex].ClubMembersList, GetIDFunction<Employee>());
                clubs[ClubIndex].ClubMembersList[EmployeeIndex].RequestVacation(StartVacation, EndVacation);
            }
        }

        #endregion Request Vacation

        #region End Of The Year Update

        internal static void EndOfTheYearUpdate()
        {
            if (departments.Count == 0)
            {
                MessageOperation("There are no departments been added yet.", ConsoleColor.Red, true, true);
            }
            else
            {
                foreach (Department entity in new List<Department>(departments))
                {
                    int DepartmentIndex = FindIndex(entity.DeptID, departments, GetIDFunction<Department>());

                    if (departments[DepartmentIndex].Staffs.Count == 0)
                    {
                        MessageOperation($"There are no employees in departmment {entity.DeptName}.", ConsoleColor.Red, true, true);
                    }
                    else
                    {
                        foreach (Employee employee in new List<Employee>(departments[DepartmentIndex].Staffs))
                        {
                            employee.EndOfYearOperation();
                            MessageOperation($"End of the year operation has been done successfully in department {departments[DepartmentIndex].DeptName}.", ConsoleColor.DarkMagenta, true, true);
                        }
                    }
                }
            }

            if (clubs.Count == 0)
            {
                MessageOperation("There are no clubs been added yet.", ConsoleColor.Red, true, true);
            }
            else
            {
                foreach (Club entity in new List<Club>(clubs))
                {
                    int ClubIndex = FindIndex(entity.ClubID, clubs, GetIDFunction<Club>());
                    if (clubs[ClubIndex].ClubMembersList.Count == 0)
                    {
                        MessageOperation($"There are no employees in departmment {entity.ClubName}.", ConsoleColor.Red, true, true);
                    }
                    else
                    {
                        foreach (Employee employee in new List<Employee>(clubs[ClubIndex].ClubMembersList))
                        {
                            employee.EndOfYearOperation();
                            MessageOperation($"End of the year operation has been done successfully in club {clubs[ClubIndex].ClubName}.", ConsoleColor.DarkMagenta, true, true);
                        }
                    }
                }
            }
        }

        #endregion End Of The Year Update
    }
}